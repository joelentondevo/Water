using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.Core.DatabaseObjects;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class StoreBO 
    {
        IDOFactory _doFactory;
        IStoreDO _storeDO;

        public StoreBO() {
            _doFactory = new DOFactory();
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
    }
}
