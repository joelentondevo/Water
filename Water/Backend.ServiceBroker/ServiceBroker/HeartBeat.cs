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
    public class HeartBeat : BackgroundService
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
            Console.WriteLine("Checking for Tasks at:" + DateTime.Now);
            while (!cancellationToken.IsCancellationRequested)
            {
                var task = processes.GetNextTask();
                if (task != null)
                {
                    taskQueue.Enqueue(task);
                    Console.WriteLine("Queued task: " + task.TaskName);
                }
                else
                {
                    await Task.Delay(tickInterval, cancellationToken);
                }

                while (taskQueue.TryDequeue(out var queueTask))
                {
                    await threadLimiter.WaitAsync(cancellationToken);

                    var execution = Task.Run(async () =>
                    {
                        DateTime startTime = DateTime.Now;
                        try
                        {
                            await processes.SendTaskForExecution(queueTask, cancellationToken);
                            DateTime endTime = DateTime.Now;
                            processes.MarkTaskComplete(queueTask, startTime, endTime);
                        }
                        catch (Exception ex)
                        {
                            DateTime endTime = DateTime.Now;
                            Console.WriteLine(ex.ToString());
                            processes.MarkTaskFailed(queueTask, startTime, endTime,  ex);
                        }
                        finally
                        {
                            threadLimiter.Release();
                        }
                    }, cancellationToken);
                    runningTasks.Add(execution);
                }
                runningTasks.RemoveAll(task => task.IsCompleted);
            }
            await Task.WhenAll(runningTasks);
        }
    }
}
