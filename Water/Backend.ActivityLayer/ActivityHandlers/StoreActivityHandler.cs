using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActitvityHandlers
{
    public class StoreActivityHandler : IStoreActivityHandler
    {
        IStoreBO _storeBO;
        IBasketBO _basketBO;
        ILibraryBO _libraryBO;

        public StoreActivityHandler(IStoreBO storeBO, IBasketBO basketBO, ILibraryBO libraryBO)
        {
            _storeBO = storeBO;
            _basketBO = basketBO;
            _libraryBO = libraryBO;
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

        public List<ProductListingEO> GetFullProductList()
        {
            return _storeBO.GetFullProductList();
        }
        
        public ProductListingEO GetProductListing(int productId)
        {
            return _storeBO.GetProductListing(productId);
        }

    }
}
