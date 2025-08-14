using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.ActivityLayer.ActitvityHandlers
{

    public class SecurityActivityHandler : ISecurityActivityHandler
    {
        ISecurityBO _securityBO;
        public SecurityActivityHandler(ISecurityBO securityBO)
        {
            _securityBO = securityBO;
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
