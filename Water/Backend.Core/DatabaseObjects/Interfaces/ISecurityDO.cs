using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface ISecurityDO
    {
        AuthenticationDetailsEO FetchAuthenticationDetails(string username);

        bool AddAuthenticationDetails(string username, string password);

        bool ChangePassword(string username, string oldPassword, string newPassword);

        int FetchUserRoles(string username);
        bool AddUserRoles(int userID, int role);
    }
}
