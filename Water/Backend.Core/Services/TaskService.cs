using Backend.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using System.Text.Json;
using Backend.Core.EntityObjects;
using System.Runtime.Serialization.Formatters;
using System.Data;

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

        public bool QueueTask(TaskEO task) 
        {
            return false;
        }

        public string serializeTaskData(object taskData)
        {
            return JsonSerializer.Serialize(taskData);
        }

        public TaskEO GetNextTask()
        {
            return _taskDO.GetNextTaskByPriority();
        }

    }
}
