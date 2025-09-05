using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using BCrypt.Net;
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
                ("@TaskPriority", task.TaskPriority));
        }

        public TaskEO GetNextTaskByPriority()
        {
            DataSet taskData = RunSP_DS("p_GetNextTaskByPriority_f");
            if (taskData != null)
            {
                DataRow row = taskData.Tables[0].Rows[0];
                TaskEO task = new TaskEO(
                    row.Field<string>("TaskType"),
                    row.Field<string>("TaskName"),
                    row.Field<string>("TaskData"),
                    row.Field<DateTime>("ScheduledStart"),
                    row.Field<int>("TaskPriority"), 
                    row.Field<int>("ID"));
                return task;
            }
            return null;
        }
    }
}
