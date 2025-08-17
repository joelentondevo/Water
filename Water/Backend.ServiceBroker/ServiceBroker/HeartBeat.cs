using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class HeartBeat
    {
        private readonly TimeSpan tickInterval = TimeSpan.FromSeconds(1);
        Processes processes;

        HeartBeat(TimeSpan tickInterval, Processes processes)
        {
            this.tickInterval = tickInterval;
            this.processes = processes;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Checking for Tasks");
                var tasks = await processes.GetQueueTasks();
                foreach (var task in tasks)
                {
                    try
                    {
                        processes.ExecuteTask(task);
                        processes.MarkTaskComplete(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        processes.MarkTaskFailed(task);
                    }
                }
 
                await Task.Delay(tickInterval, cancellationToken);
            }
        }
    }
}
