using Backend.ServiceBroker.TaskExecutors.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.ServiceBroker.TaskExecutors
{
    public class LibraryExecutor : ILibraryExecutor
    {
        ITaskService _taskService;
        IStoreActivityHandler _activityHandler;
        public LibraryExecutor(ITaskService taskService, IStoreActivityHandler storeActivityHandler) 
        { 
            _taskService = taskService;
            _activityHandler = storeActivityHandler;
        }

        public void ExecuteTask(TaskEO task)
        {
            switch (task.TaskName)
            {
                case "AddProductToLibrary":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var taskData = (AddProductToLibraryEO)_taskService.DeserializeTaskData(task.TaskData, typeof(AddProductToLibraryEO));
                    _activityHandler.AddProductToUserLibrary(taskData.UserID, taskData.ProductID, taskData.ProductKey);
                    break;
            }
        }
    }
}
