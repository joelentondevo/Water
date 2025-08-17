using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class Processes
    {
        internal async Task<List<TaskEO>> GetQueueTasks()
        {
            return new List<TaskEO>();
        }

        internal void ExecuteTask(TaskEO task)
        {

        }

        internal bool MarkTaskComplete(TaskEO task)
        {
            return false;
        }

        internal bool MarkTaskFailed(TaskEO task)
        {
            return false;
        }
    }
}
