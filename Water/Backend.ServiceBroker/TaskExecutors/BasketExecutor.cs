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
        IBasketActivityHandler _basketActivityHandler;
        public BasketExecutor(ITaskService taskService, IBasketActivityHandler basketActivityHandler)
        {
            _taskService = taskService;
            _basketActivityHandler = basketActivityHandler;
        }
        public void ExecuteTask(TaskEO task) 
        {
            switch (task.TaskName)
            {
                case "GenerateUserBasket":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var GenerateUserBasketTaskData = (int)_taskService.DeserializeTaskData(task.TaskData, typeof(int));
                    _basketActivityHandler.GenerateUserBasket(GenerateUserBasketTaskData);
                    break;
                case "ClearUserBasket":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var ClearUserBasketTaskData = (int)_taskService.DeserializeTaskData(task.TaskData, typeof(int));
                    _basketActivityHandler.ClearUserBasket(ClearUserBasketTaskData);
                    break;
            }
        }
    }
}
