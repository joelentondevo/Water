using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class OrderMetaDataEO
    {
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderType { get; set; }

        public OrderMetaDataEO(int userID, DateTime orderDate, int orderType) 
        { 
            this.UserID = userID;
            this.OrderDate = orderDate; 
            this.OrderType = orderType;
        }

    }
}
