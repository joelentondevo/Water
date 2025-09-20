using Backend.ServiceBroker.TaskExecutors.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.ServiceBroker.TaskExecutors
{
    public class LibraryExecutor : ILibraryExecutor
    {
        ITaskService _taskService;
        ILibraryActivityHandler _libraryActivityHandler;
        public LibraryExecutor(ITaskService taskService, ILibraryActivityHandler libraryActivityHandler) 
        { 
            _taskService = taskService;
            _libraryActivityHandler = libraryActivityHandler;
        }

        public void ExecuteTask(TaskEO task)
        {
            switch (task.TaskName)
            {
                case "AddProductToLibrary":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var taskData = (AddProductToLibraryEO)_taskService.DeserializeTaskData(task.TaskData, typeof(AddProductToLibraryEO));
                    _libraryActivityHandler.AddProductToUserLibrary(taskData.UserID, taskData.ProductID, taskData.ProductKey);
                    break;
            }
        }
    }
}
