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
        ICorrespondenceBO _correspondenceBO;
        IBOFactory _bOFactory;
        IServicesFactory _servicesFactory;
        IOrderBO _orderBO;
        ITaskService _taskService;

        public StoreActivityHandler(IBOFactory bOFactory, IServicesFactory servicesFactory)
        {
            _servicesFactory = servicesFactory;
            _bOFactory = bOFactory;
            _storeBO = _bOFactory.CreateStoreBO();
            _basketBO = _bOFactory.CreateBasketBO();
            _libraryBO = _bOFactory.CreateLibraryBO();
            _orderBO = _bOFactory.CreateOrderBO();
            _correspondenceBO = _bOFactory.CreateCorrespondenceBO();
            _taskService = _servicesFactory.CreateTaskService();
        }

        public bool AddProductToUserLibrary(int userId, int productId, string ProductKey)
        {
            return _libraryBO.AddProductToUserLibrary(userId, productId, ProductKey);
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

            //order registering logic to go here

            if (checkoutBasket != null) {
                foreach (var item in checkoutBasket)
                {
                    AddProductToLibraryEO addProductToLibraryEO = new AddProductToLibraryEO(userId, item.ProductListing.Id, _libraryBO.GenerateProductKey(16, 4));
                    _libraryBO.RaiseAddProductToLibraryTask(addProductToLibraryEO);
                }
                ReceiptDataEO receiptData = new ReceiptDataEO(checkoutBasket, DateTime.Now, "username");
                _correspondenceBO.RaiseReceiptTask(receiptData);
            }
        }
    }
}
