using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class OrderDataEO
    {
        public OrderMetaDataEO metaDataEO { get; set; }
        public OrderDetailDataEO detailDataEO { get; set; }

        public OrderDataEO(OrderMetaDataEO metaDataEO, OrderDetailDataEO orderDetailDataEO) 
        { 
            this.metaDataEO = metaDataEO; 
            this.detailDataEO = orderDetailDataEO;
        }
    }
}
