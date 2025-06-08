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

        public void AddItemToBasket(int itemId, int quantity)
        {
        }
        public void RemoveItemFromBasket(int itemId)
        {
        }
        public List<ProductInstanceEO> GetBasketItems()
        {
            return new List<ProductInstanceEO>();
        }
        public void ClearBasket()
        {
        }

        public void GenerateUserBasket(int userID)
        {
            _basketDO.GenerateUserBasket(userID);
        }



    }
}
