using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ServiceBroker.ServiceBroker.Interfaces;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class HeartBeat : BackgroundService
    {
        private readonly TimeSpan tickInterval = TimeSpan.FromSeconds(1);
        readonly IProcesses processes;

        public HeartBeat(IProcesses processes)
        {
            this.processes = processes;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Checking for Tasks at:" + DateTime.Now);
                var task = processes.GetNextTask();
                if (task != null) {
                    try {
                        Console.WriteLine("Executing task " + task.name + " at:" + DateTime.Now);
                        processes.ExecuteTask(task, cancellationToken);
                    processes.MarkTaskComplete(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        processes.MarkTaskFailed(task);
                    }
                } else {
                    Console.WriteLine("No task found at:" + DateTime.Now);
                    await Task.Delay(tickInterval, cancellationToken);
                }
            }
        }
    }
}
