using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers
{
    public class BasketActivityHandler : IBasketActivityHandler
    {
        IBOFactory _bOFactory;
        IBasketBO _basketBO;

        public BasketActivityHandler(IBOFactory bOFactory)
        {
            _bOFactory = bOFactory;
            _basketBO = _bOFactory.CreateBasketBO();
        }

        public void GenerateUserBasket(int userId)
        {
            _basketBO.GenerateUserBasket(userId);
            return;
        }

        public List<BasketItemEO> GetBasketItemsByUserId(int userId)
        {
            return _basketBO.GetBasketItems(userId);
        }

        public bool AddProductToUserBasket(int userId, int itemId, int quantity)
        {
            return _basketBO.AddProductToBasket(userId, itemId, quantity);
        }

        public bool RemoveProductFromUserBasket(int userId, int itemId)
        {
            return _basketBO.RemoveItemFromBasket(userId, itemId);
        }

        public bool ClearUserBasket(int userId)
        {
            return _basketBO.ClearUserBasket(userId);
        }
    }
}
