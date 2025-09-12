using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    internal class GenerateUserBasketEO
    {
        public int UserID { get; set; }
        public GenerateUserBasketEO(int userID)
        {
            this.UserID = userID;
        }
    }
}