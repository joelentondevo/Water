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

        public async Task ExecuteTask(TaskEO task, CancellationToken cancellationToken)
        {
            switch(task.Type)
            {
                case "Correspondence":

                    break;
            }

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
