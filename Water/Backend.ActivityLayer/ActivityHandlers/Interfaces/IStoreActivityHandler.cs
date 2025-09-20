using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers.Interfaces
{
    public interface IStoreActivityHandler
    {
        List<ProductListingEO> GetFullProductList();

        ProductListingEO GetProductListing(int productId);
    }
}
