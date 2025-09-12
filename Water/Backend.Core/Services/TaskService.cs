using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using System;
using System.Text.Json;

namespace Backend.Core.Services
{
    public class TaskService : ITaskService
    {
        IDOFactory _dOfactory;
        ITaskDO _taskDO;
        public TaskService(IDOFactory dOfactory)
        {
            _dOfactory = dOfactory;
            _taskDO = dOfactory.CreateTaskDO();
        }

        public bool ScheduleTask(TaskEO task) 
        {
            return _taskDO.ScheduleTask(task);
        }

        public string SerializeTaskData(object taskData)
        {
            return JsonSerializer.Serialize(taskData);
        }

        public object DeserializeTaskData(string taskData, Type objectType)
        {
            return JsonSerializer.Deserialize(taskData, objectType);
        }

        public TaskEO GetNextTask()
        {
            return _taskDO.GetNextTaskByPriority();
        }

    }
}
