using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface ISecurityBO
    {
        string ValidateAuthenticationDetails(string inputUsername, string inputPassword);
        bool AddAuthenticationDetails(string inputUsername, string inputPassword);
        int GetUserIDFromAuthenticationDetails(string inputUsername);
        bool AddUserRoles(int userID, int role);
    }
}
