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
        IStoreDO _storeDO;

        public StoreBO(IStoreDO storeDO) => _storeDO = storeDO;
        public List<ProductListingEO> GetFullProductList()
        {
            List<ProductListingEO> productList = _storeDO.GetStoreListings();
            return productList;
        }
    }
}
