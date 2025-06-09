using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;

namespace Backend.Core.BusinessObjects
{
    public class BasketBO
    {
        IDOFactory _dOFactory;
        IBasketDO _basketDO;

        public BasketBO()
        {
            _dOFactory = new DOFactory();
            _basketDO = _dOFactory.CreateBasketDO();
        }
        public void GenerateUserBasket(int userID)
        {
            _basketDO.GenerateUserBasket(userID);
        }

        public bool AddProductToBasket(int userId, int itemId, int quantity)
        {
            return _basketDO.AddProductToBasket(userId, itemId, quantity);
        }

        public bool RemoveItemFromBasket(int userId, int itemId)
        {
            return _basketDO.RemoveProductFromBasket(userId, itemId);
        }

        public bool ClearUserBasket(int userId)
        {
            return _basketDO.ClearUserBasket(userId);
        }

        public List<ProductInstanceEO> GetBasketItems()
        {
            return new List<ProductInstanceEO>();
        }





    }
}
