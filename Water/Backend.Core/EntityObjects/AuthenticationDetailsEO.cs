using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class AuthenticationDetailsEO
    {
        public int UserID { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public AuthenticationDetailsEO(int userID, string username, string password)
        {
            UserID = userID;
            Username = username;
            Password = password;
        }
    }
}
