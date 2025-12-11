using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers.Interfaces
{
    public interface ISecurityActivityHandler
    {
        string UserLoginAttempt(string username, string password);

        bool UserRegistration(string username, string password, int role);
    }
}
