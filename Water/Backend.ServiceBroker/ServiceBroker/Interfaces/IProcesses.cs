using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceBroker.ServiceBroker.Interfaces
{
    public interface IProcesses
    {
        TaskEO GetNextTask();


        Task SendTaskForExecution(TaskEO task, CancellationToken cancellationToken);


        bool MarkTaskComplete(TaskEO task, DateTime startTime, DateTime endTime);


        bool MarkTaskFailed(TaskEO task, DateTime startTime, DateTime failTime, Exception ex);
        
    }
}
