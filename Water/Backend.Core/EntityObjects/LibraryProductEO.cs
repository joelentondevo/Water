using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class LibraryProductEO
    {
        public LibraryProductEO(ProductEO product, string productKey, DateTime dateAdded)
        {
            Product = product;
            ProductKey = productKey;
            DateAdded = dateAdded;
        }

        public ProductEO Product { get; set; }
        public string ProductKey { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
