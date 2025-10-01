using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects
{
    internal class OrderDO : BaseDO, IOrderDO
    {
        public bool AddOrderEntry(OrderMetaDataEO orderData)
        {
            return RUNSP_Bool("p_AddOrderEntry_i", ("@UserID", orderData.UserID), ("@OrderDate", orderData.OrderDate), ("@OrderType", orderData.OrderType));
        }
    }
}
