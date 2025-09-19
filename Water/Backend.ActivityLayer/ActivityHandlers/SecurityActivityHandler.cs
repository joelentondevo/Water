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
        IBOFactory _BOFactory;
        IServicesFactory _servicesFactory;
        ISecurityBO _securityBO;
        ITaskService _taskService;
        public SecurityActivityHandler(IBOFactory bOFactory, IServicesFactory servicesFactory)
        {
            _BOFactory = bOFactory;
            _servicesFactory = servicesFactory;
            _securityBO = _BOFactory.CreateSecurityBO();
            _taskService = _servicesFactory.CreateTaskService();
        }

        public string UserLoginAttempt(string username, string password)
        {
            return _securityBO.ValidateAuthenticationDetails(username, password);
        }

        public bool UserRegistration(string username, string password)
        {
            bool result =  _securityBO.AddAuthenticationDetails(username, password);
            int userID = _securityBO.GetUserIDFromAuthenticationDetails(username);
            string taskdata = _taskService.SerializeTaskData(userID);
            TaskEO newTask = new TaskEO("Basket", "GenerateUserBasket", taskdata, DateTime.Now, 5);
            _taskService.ScheduleTask(newTask);
            return result;
        }
    }
}
