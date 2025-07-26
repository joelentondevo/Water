using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface IBasketBO
    {
        void GenerateUserBasket(int userID);

        bool AddProductToBasket(int userId, int itemId, int quantity);

        bool RemoveItemFromBasket(int userId, int itemId);


        bool ClearUserBasket(int userId);

        List<BasketItemEO> GetBasketItems(int userId);

    }
}
