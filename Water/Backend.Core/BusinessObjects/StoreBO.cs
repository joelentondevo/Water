using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.Core.DatabaseObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class StoreBO : IStoreBO
    {
        IDOFactory _doFactory;
        IStoreDO _storeDO;

        public StoreBO(IDOFactory dOFactory) {
            _doFactory = dOFactory;
            _storeDO = _doFactory.CreateStoreDO();
        }
        public List<ProductListingEO> GetFullProductList()
        {
            List<ProductListingEO> productList = _storeDO.GetStoreListings();
            return productList;
        }
        public ProductListingEO GetProductListing(int productId)
        {  
            return _storeDO.GetProductListing(productId);
        }

        public bool AddProductListing(ProductListingEO productListing)
        {
            return _storeDO.AddProductListing(productListing);
        }
    }
}
