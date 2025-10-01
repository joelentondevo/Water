using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.Core.DatabaseObjects
{
    internal class BasketDO : BaseDO, IBasketDO
    {
        public bool GenerateUserBasket(int userID)
        {
            return RUNSP_Bool("p_GenerateUserBasket_f", ("@UserID", userID));
        }

        public bool AddProductToBasket(int userID, int productID, int quantity)
        {
            return RUNSP_Bool("p_AddItemToBasket_f",
                ("@UserID", userID),
                ("@ProductID", productID),
                ("@Quantity", quantity));
        }
        public bool RemoveProductFromBasket(int userID, int productID)
        {
            return RUNSP_Bool("p_RemoveItemFromBasket_f",
                ("@UserID", userID),
                ("@ProductID", productID));
        }
        public bool ClearUserBasket(int userID)
        {
            return RUNSP_Bool("p_ClearUserBasket_f", ("@UserID", userID));
        }
        public List<BasketEntryEO> GetBasketItems(int userID)
        {
            DataSet ds = RunSP_DS("p_GetBasketItems_f", ("@UserID", userID));
            List<BasketEntryEO> items = new List<BasketEntryEO>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                    items.Add(new BasketEntryEO
                        (row.Field<int>("ProductID"),row.Field<int>("Quantity")));
            }
            return items;
        }
    }
}
