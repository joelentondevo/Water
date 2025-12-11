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
        public bool ScheduleTask(TaskEO task)
        {
            return RunSP_Bool("p_ScheduleTask_i",
                ("@TaskType", task.TaskType),
                ("@TaskName", task.TaskName),
                ("@TaskData", task.TaskData),
                ("@ScheduledStart", task.ScheduledStart),
                ("@TaskPriority", task.TaskPriority));
        }

        public TaskEO GetNextTaskByPriority()
        {
            DataSet taskData = RunSP_DS("p_GetNextTaskByPriority_f");
            if (taskData != null && taskData.Tables.Count > 0 && taskData.Tables[0].Rows.Count > 0)
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

        public bool UpdateTaskStatus(TaskEO task, string status)
        {
            return RunSP_Bool("p_UpdateTaskStatus_u", ("@ID", task.Id), ("@TaskStatus", status));
        }

        public bool UpdateTaskLog(TaskEO task, object executionDetails)
        {
            throw new NotImplementedException();
        }

        public bool MarkTaskComplete(TaskEO task, DateTime startTime, DateTime endTime)
        {
            bool LogTask = RunSP_Bool("p_LogTaskComplete_i",
                ("@TaskID", task.Id),
                ("@TaskType", task.TaskType),
                ("@TaskData", task.TaskData),
                ("@TaskStatus", "Complete"),
                ("@StartedAt", startTime),
                ("@CompletedAt", endTime),
                ("@Duration", (endTime - startTime).TotalMilliseconds),
                ("@DateLogCreated", DateTime.Now));

            bool UpdateQueueStatus = RunSP_Bool("p_UpdateTaskStatus_u", ("@ID", task.Id), ("@TaskStatus", "Completed"));

            if (LogTask && UpdateQueueStatus)
            {
                return true;
            }
            return false;
        }

        public bool MarkTaskFailed(TaskEO task, DateTime startTime, DateTime endTime, Exception ex)
        {
            bool LogTask = RunSP_Bool("p_LogTaskFailed_i",
               ("@TaskID", task.Id),
               ("@TaskType", task.TaskType),
               ("@TaskData", task.TaskData),
               ("@TaskStatus", "Failed"),
               ("@StartedAt", startTime),
               ("@CompletedAt", endTime),
               ("@Duration", (endTime - startTime).TotalMilliseconds),
               ("@ErrorMessage", ex.Message),
               ("@DateLogCreated", DateTime.Now));

            bool UpdateQueueStatus = RunSP_Bool("p_UpdateTaskStatus_u", ("@ID", task.Id), ("@TaskStatus", "Failed"));

            if (LogTask && UpdateQueueStatus)
            {
                return true;
            }
            return false;
        }

    }
}
