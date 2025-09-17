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
        bool ScheduleTask(TaskEO task);

        TaskEO GetNextTaskByPriority();

        bool MarkTaskComplete(TaskEO task, DateTime startTime, DateTime endTime);

        bool MarkTaskFailed(TaskEO task, DateTime startTime, DateTime endTime, Exception ex);
    }
}
