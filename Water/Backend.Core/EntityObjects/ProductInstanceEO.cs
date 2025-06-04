using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class ProductInstanceEO
    {
        public ProductListingEO Product { get; set; }
        public int Quantity { get; set; }

        public ProductInstanceEO(ProductListingEO ProductListing, int quantity)
        {
            ProductListing = ProductListing ?? throw new ArgumentNullException(nameof(ProductListing), "Product cannot be null");
            Quantity = quantity >= 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative");
        }
    }
}
