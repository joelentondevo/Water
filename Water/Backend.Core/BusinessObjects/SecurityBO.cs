using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using BCrypt.Net;
using Backend.Core.DatabaseObjects;

namespace Backend.Core.BusinessObjects
{
    public class SecurityBO
    {
        IDOFactory _dOFactory;
        ISecurityDO _securityDO;    

        public SecurityBO()
        {
            _dOFactory = new DOFactory();
            _securityDO = _dOFactory.CreateSecurityDO();    
        }

        public bool ValidateAuthenticationDetails(string username, string password)
        {
            var user = _securityDO.FetchAuthenticationDetails(username);
            // todo - add password authentication using BCrypt
            if (user == null)
            {
                return false; // User not found
            }
            else
            {
                return true;
            }
        }

        public bool AddAuthenticationDetails(string username, string password)
        {
            if (_securityDO.FetchAuthenticationDetails(username) != null)
            {
                return false; // User already exists
            }
            return _securityDO.AddAuthenticationDetails(username, password);
        }
    }
}
