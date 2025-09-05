using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
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
        ITaskService _taskService;

        public StoreActivityHandler(IStoreBO storeBO, IBasketBO basketBO, ILibraryBO libraryBO, ITaskService taskService)
        {
            _storeBO = storeBO;
            _basketBO = basketBO;
            _libraryBO = libraryBO;
            _taskService = taskService;
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

        public void Checkout(int userId)
        {
            List<BasketItemEO> checkoutBasket = _basketBO.GetBasketItems(userId);
            if (checkoutBasket != null) {
                foreach (var item in checkoutBasket)
                {
                    string productKey = _libraryBO.GenerateProductKey(16, 4);
                    AddProductToLibraryEO addProductToLibraryEO = new AddProductToLibraryEO(userId, item.ProductListing.Id, productKey);
                    string taskdata = _taskService.SerializeTaskData(addProductToLibraryEO);
                    TaskEO newTask = new TaskEO("Library", "AddProductToLibrary", taskdata, DateTime.Now, 5);
                    _taskService.QueueTask(newTask);
                }
            }
        }

    }
}
