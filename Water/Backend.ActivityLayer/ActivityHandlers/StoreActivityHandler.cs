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
        IBOFactory _bOFactory;
        IServicesFactory _servicesFactory;
        ITaskService _taskService;

        public StoreActivityHandler(IBOFactory bOFactory, IServicesFactory servicesFactory, ITaskService taskService)
        {
            _bOFactory = bOFactory;
            _storeBO = _bOFactory.CreateStoreBO();
            _servicesFactory = servicesFactory;
            _taskService = taskService;
        }

        public List<ProductListingEO> GetFullProductList()
        {
            return _storeBO.GetFullProductList();
        }
        
        public ProductListingEO GetProductListing(int productId)
        {
            return _storeBO.GetProductListing(productId);
        }

        public bool AddProductListing(ProductListingEO productListing)
        {
              return _storeBO.AddProductListing(productListing);
        }
    }
}
