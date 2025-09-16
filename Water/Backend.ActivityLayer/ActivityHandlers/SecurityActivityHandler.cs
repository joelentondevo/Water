using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActitvityHandlers
{

    public class SecurityActivityHandler : ISecurityActivityHandler
    {
        ISecurityBO _securityBO;
        ITaskService _taskService;
        public SecurityActivityHandler(ISecurityBO securityBO, ITaskService taskCreationService)
        {
            _securityBO = securityBO;
            _taskService = taskCreationService;
        }

        public string UserLoginAttempt(string username, string password)
        {
            return _securityBO.ValidateAuthenticationDetails(username, password);
        }

        public bool UserRegistration(string username, string password)
        {
            return _securityBO.AddAuthenticationDetails(username, password);
            int userID = _securityBO.GetUserIDFromAuthenticationDetails(username, password);
            string taskdata = _taskService.SerializeTaskData(userID);
            TaskEO newTask = new TaskEO("Basket", "GenerateUserBasket", taskdata, DateTime.Now, 5);
            _taskService.ScheduleTask(newTask);
        }
    }
}
