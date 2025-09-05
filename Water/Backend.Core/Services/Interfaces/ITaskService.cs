using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services.Interfaces
{
    public interface ITaskService
    {
        bool QueueTask(TaskEO task);

        string SerializeTaskData(object task);

        TaskEO GetNextTask();
    }
}
