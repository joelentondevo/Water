using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using Backend.ServiceBroker.TaskExecutors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ServiceBroker.TaskExecutors
{
    public class BasketExecutor : IBasketExecutor
    {
        ITaskService _taskService;
        IStoreActivityHandler _activityHandler;
        public BasketExecutor(ITaskService taskService, IStoreActivityHandler storeActivityHandler)
        {
            _taskService = taskService;
            _activityHandler = storeActivityHandler;
        }
        public void ExecuteTask(TaskEO task) 
        {
            switch (task.TaskName)
            {
                case "GenerateUserBasket":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var taskData = (AddProductToLibraryEO)_taskService.DeserializeTaskData(task.TaskData, typeof(AddProductToLibraryEO));
                    _activityHandler.GenerateUserBasket(taskData.UserID);
                    break;
            }
        }
    }
}
