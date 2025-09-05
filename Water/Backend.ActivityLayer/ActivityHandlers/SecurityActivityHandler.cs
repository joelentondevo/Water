using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.Services.Interfaces;

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
        }
    }
}
