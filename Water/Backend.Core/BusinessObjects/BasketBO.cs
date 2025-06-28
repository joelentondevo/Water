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

        public List<BasketItemEO> GetBasketItems(int userId)
        {
            List<BasketEntryEO> basketList = _basketDO.GetBasketItems(userId);
            List<BasketItemEO> list = new List<BasketItemEO>();
            StoreBO storeBO = new StoreBO();
            foreach (var item in basketList)
            {
                ProductListingEO productListing = storeBO.GetProductListing(item.ProductID);
                if (productListing == null)
                {
                    continue; // Skip if product listing is not found
                } else
                {
                    list.Add(new BasketItemEO(productListing, item.Quantity));
                }
            }
            return list;
        }
    }
}
