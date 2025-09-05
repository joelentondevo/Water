using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class TaskEO
    {
        public int Id { get; set; }
        public string TaskType {  get; set; }
        public string TaskName { get; set; }
        public string TaskData { get; set; }
        public DateTime ScheduledStart { get; set; }
        public int TaskPriority { get; set; }

        public TaskEO(string taskType, string taskName, string taskData, DateTime scheduledStart, int taskPriority, int id = 0)
        {
            Id = id;
            TaskType = taskType;
            TaskName = taskName;
            TaskData = taskData;
            ScheduledStart = scheduledStart;
            TaskPriority = taskPriority;
        }
    }
}
