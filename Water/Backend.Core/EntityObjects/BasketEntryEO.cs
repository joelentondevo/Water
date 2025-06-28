using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class BasketEntryEO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public BasketEntryEO(int productId, int quantity)
        {
            ProductID = productId;
            Quantity = quantity;
        }
    }
}
