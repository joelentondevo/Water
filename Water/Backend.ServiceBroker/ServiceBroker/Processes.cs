using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.ServiceBroker.ServiceBroker.Interfaces;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class Processes : IProcesses
    {
        public TaskEO GetNextTask()
        {
            return null;
        }

        public bool ExecuteTask(TaskEO task, CancellationToken cancellationToken)
        {
            return false;

        }

        public bool MarkTaskComplete(TaskEO task)
        {
            return false;
        }

        public bool MarkTaskFailed(TaskEO task)
        {
            return false;
        }
    }
}
