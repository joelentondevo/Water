using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class UserDetailsEO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public UserDetailsEO(int UserID, string UserName)
        {
            this.UserID = UserID;
            this.UserName = UserName;
        }
    }
}
