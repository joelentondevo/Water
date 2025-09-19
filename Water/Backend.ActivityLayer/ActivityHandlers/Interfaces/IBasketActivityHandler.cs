using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers.Interfaces
{
    public interface IBasketActivityHandler
    {
        List<BasketItemEO> GetBasketItemsByUserId(int userId);
        void GenerateUserBasket(int userId);

        bool AddProductToUserBasket(int userId, int itemId, int quantity);


        bool RemoveProductFromUserBasket(int userId, int itemId);

        bool ClearUserBasket(int userId);
    }
}
