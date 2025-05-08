using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.Core.DatabaseObjects;

namespace Backend.Core.BusinessObjects
{
    public class StoreBO
    {
        public List<ProductListingEO> GetFullProductList()
        {
            List<ProductListingEO> productList = new StoreDO().GetStoreListings();
            return productList;
        }
    }
}
