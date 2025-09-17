using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.ServiceBroker.ServiceBroker.Interfaces;
using Backend.Core.Services.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.ServiceBroker.TaskExecutors.Interfaces;

namespace Backend.ServiceBroker.ServiceBroker
{
    internal class Processes : IProcesses
    {
        ITaskService _taskService;
        IDOFactory _dOFactory;
        ITaskDO _taskDO;
        ILibraryExecutor _libraryExecutor;
        IBasketExecutor _basketExecutor;

        public Processes(ITaskService taskService, IDOFactory dOFactory, ILibraryExecutor libraryExecutor, IBasketExecutor basketExecutor)
        {
            _taskService = taskService;
            _dOFactory = dOFactory;
            _taskDO = _dOFactory.CreateTaskDO();
            _libraryExecutor = libraryExecutor;
            _basketExecutor = basketExecutor;
        }
        public TaskEO GetNextTask()
        {
            return _taskDO.GetNextTaskByPriority();
        }

        public async Task SendTaskForExecution(TaskEO task, CancellationToken cancellationToken)
        {
            switch(task.TaskType)
            {
                case "Correspondence":

                    break;
                case "Library":
                    _libraryExecutor.ExecuteTask(task);

                    break;
                case "Basket":
                    _basketExecutor.ExecuteTask(task);
                    break;

            }

        }

        public bool MarkTaskComplete(TaskEO task, DateTime startTime, DateTime endTime)
        {
            return _taskDO.MarkTaskComplete(task, startTime, endTime);
        }

        public bool MarkTaskFailed(TaskEO task, DateTime startTime, DateTime endTime, Exception ex)
        {
            return false;
            return _taskDO.MarkTaskFailed(task, startTime, endTime, ex);
        }
    }
}
