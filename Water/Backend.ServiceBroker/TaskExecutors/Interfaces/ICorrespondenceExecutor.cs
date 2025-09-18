using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceBroker.TaskExecutors.Interfaces
{
    public interface ICorrespondenceExecutor
    {
        void ExecuteTask(TaskEO task);
    }
}
