using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.Core.DatabaseObjects
{
    internal class SecurityDO : BaseDO, ISecurityDO
    {
        public AuthenticationDetailsEO FetchUser(string username, string password)
        {


            return null;
        }

        public bool RegisterUser(string username, string password, string email)
        {
            // Implement user registration logic here
            return false;
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Implement password change logic here
            return false;
        }


    }
}
