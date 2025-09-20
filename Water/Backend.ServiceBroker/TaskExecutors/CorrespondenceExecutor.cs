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
    public class CorrespondenceExecutor : ICorrespondenceExecutor
    {
        public ITaskService _taskService;
        public ICorrespondenceActivityHandler _correspondenceActivityHandler;

        public CorrespondenceExecutor(ITaskService taskService, ICorrespondenceActivityHandler correspondenceActivityHandler)
        { 
            _taskService = taskService;
            _correspondenceActivityHandler = correspondenceActivityHandler;
        }

        public void ExecuteTask(TaskEO task)
        {
            switch (task.TaskName)
            {
                case "GenerateOrderReceipt":
                    Console.WriteLine("Started Execution on " + task.TaskName);
                    var taskData = (ReceiptDataEO)_taskService.DeserializeTaskData(task.TaskData, typeof(ReceiptDataEO));
                    _correspondenceActivityHandler.GenerateOrderReceipt(taskData);
                    break;
            }
        }

    }
}
