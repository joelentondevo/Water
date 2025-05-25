using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    internal class AuthenticationDetailsEO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AuthenticationDetailsEO(string username, string password, string email)
        {
            Username = username;
            Password = password;
 
        }
    }
}
