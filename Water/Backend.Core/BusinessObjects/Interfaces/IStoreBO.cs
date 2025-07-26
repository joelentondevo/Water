using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface IStoreBO
    {
        List<ProductListingEO> GetFullProductList();

        ProductListingEO GetProductListing(int productId);
    }
}
