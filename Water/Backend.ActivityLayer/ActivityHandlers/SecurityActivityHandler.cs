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
        ISecurityBO _securityBO;
        IBasketBO _basketBO;
        public SecurityActivityHandler(IBOFactory bOFactory)
        {
            _BOFactory = bOFactory;
            _securityBO = _BOFactory.CreateSecurityBO();
            _basketBO = _BOFactory.CreateBasketBO();
        }

        public string UserLoginAttempt(string username, string password)
        {
            return _securityBO.ValidateAuthenticationDetails(username, password);
        }

        public bool UserRegistration(string username, string password)
        {
            bool result =  _securityBO.AddAuthenticationDetails(username, password);
            int userID = _securityBO.GetUserIDFromAuthenticationDetails(username);
            _basketBO.RaiseGenerateUserBasketTask(userID);
            return result;
        }
    }
}
