using Backend.ServiceBroker.ServiceBroker.Interfaces;
using Backend.Core.EntityObjects;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class HeartBeat : BackgroundService
    {
        private readonly TimeSpan tickInterval = TimeSpan.FromSeconds(1);
        private readonly ConcurrentQueue<TaskEO> taskQueue = new ConcurrentQueue<TaskEO>();
        readonly IProcesses processes;
        private readonly SemaphoreSlim threadLimiter = new SemaphoreSlim(10);

        public HeartBeat(IProcesses processes)
        {
            this.processes = processes;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var runningTasks = new List<Task>();

            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Checking for Tasks at:" + DateTime.Now);
                var task = processes.GetNextTask();
                if (task != null)
                {
                    taskQueue.Enqueue(task);
                    Console.WriteLine("Queued task: " + task.Name);
                }
                else
                {
                    Console.WriteLine("No new task found at:" + DateTime.Now);
                }

                while (taskQueue.TryDequeue(out var queueTask))
                {
                    await threadLimiter.WaitAsync(cancellationToken);

                    var execution = Task.Run(async () =>
                    {
                        try
                        {
                            Console.WriteLine("Executing task " + queueTask.Name + " at:" + DateTime.Now);
                            await processes.ExecuteTask(queueTask, cancellationToken);
                            processes.MarkTaskComplete(queueTask);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            processes.MarkTaskFailed(queueTask);
                        }
                        finally
                        {
                            threadLimiter.Release(); // Free up the slot
                        }
                    }, cancellationToken);
                    runningTasks.Add(execution);
                }
                runningTasks.RemoveAll(task => task.IsCompleted);
                await Task.Delay(tickInterval, cancellationToken);
            }
            await Task.WhenAll(runningTasks);
        }
    }
}
