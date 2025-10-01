using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class OrderDataEO
    {
        public int OrderID { get; set; }
        public OrderMetaDataEO MetaData { get; set; }
        public List<BasketItemEO> OrderBasket { get; set; }

        public OrderDataEO(int orderID, OrderMetaDataEO metaDataEO, List<BasketItemEO> basketItems) 
        { 
            OrderID = orderID;
            MetaData = metaDataEO; 
            OrderBasket = basketItems;
        }
    }
}
