using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;

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
            return RUNSP_Bool("p_AddProductToBasket_f",
                ("@UserID", userID),
                ("@ProductID", productID),
                ("@Quantity", quantity));
        }
        public bool RemoveProductFromBasket(int userID, int productID)
        {
            return RUNSP_Bool("p_RemoveProductFromBasket_f",
                ("@UserID", userID),
                ("@ProductID", productID));
        }
        public bool ClearUserBasket(int userID)
        {
            return RUNSP_Bool("p_ClearUserBasket_f", ("@UserID", userID));
        }
    }
}
