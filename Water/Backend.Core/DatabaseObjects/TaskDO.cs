using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects
{
    internal class TaskDO : BaseDO, ITaskDO
    {
        public bool QueueTask(TaskEO task)
        {
            return RUNSP_Bool("p_QueueTask_i", 
                ("@TaskType", task.TaskType),
                ("@TaskName", task.TaskName),
                ("@TaskData", task.TaskData),
                ("@ScheduledStart", task.ScheduledStart),
                ("@Priority", task.TaskPriority));
        }

        public TaskEO GetNextTaskByPriority()
        {
            DataSet taskData = RunSP_DS("p_GetNextTaskByPriority_f");
            if (taskData != null)
            {
                DataRow row = taskData.Tables[0].Rows[0];
                TaskEO task = new TaskEO
                {
                    Id = row.Field<int>("ID"),
                    TaskType = row.Field<string>("TaskType"),
                    TaskName = row.Field<string>("TaskName"),
                    TaskData = row.Field<string>("TaskData"),
                    ScheduledStart = row.Field<DateTime>("ScheduledStart"),
                    TaskPriority = row.Field<int>("TaskPriority"),
                };
                return task;
            }
            return null;
        }
    }
}
