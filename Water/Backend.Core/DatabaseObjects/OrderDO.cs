using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects
{
    internal class OrderDO : BaseDO, IOrderDO
    {
        public int AddOrderEntry(OrderMetaDataEO orderData)
        {
            DataSet data =  RunSP_DS("p_AddOrderEntry_i", ("@UserID", orderData.UserID), ("@OrderDate", orderData.OrderDate), ("@OrderType", orderData.OrderType));
            return (int)data.Tables[0].Rows[0]["ID"];
        }

        public bool AddOrderDetailEntries(OrderDataEO orderData)
        {
            bool AllItems = true;
            foreach(var Item in orderData.OrderBasket)
            {
               bool AddItem = RUNSP_Bool("p_AddOrderDetailEntry_i", ("@OrderID", orderData.OrderID), ("@ProductID", Item.ProductListing.Id), ("@Price", Item.ProductListing.Price), ("@Quantity", Item.Quantity));
                AllItems = AllItems && AddItem;
            }
            return AllItems;
        }

    }
}
