using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface ITaskDO
    {
        bool QueueTask(TaskEO task);

        TaskEO GetNextTaskByPriority();
    }
}
