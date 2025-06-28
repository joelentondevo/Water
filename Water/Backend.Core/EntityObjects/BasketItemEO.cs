using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class BasketItemEO
    {
        public ProductListingEO ProductListing { get; set; }
        public int Quantity { get; set; }
        public BasketItemEO(ProductListingEO productListing, int quantity)
        {
            ProductListing = productListing;
            Quantity = quantity;
        }
    }
}
