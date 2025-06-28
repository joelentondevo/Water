using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface IStoreDO
    {
        List<ProductListingEO> GetStoreListings();
        ProductListingEO GetProductListing(int productId);
    }
}
