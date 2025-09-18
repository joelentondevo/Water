using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.EntityObjects
{
    public class ReceiptDataEO
    {   
        public List<BasketItemEO> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public decimal Total {  get; set; }

        public ReceiptDataEO(List<BasketItemEO> products, DateTime orderDate, string username) 
        { 
            this.Products = products;
            this.OrderDate = orderDate;
            this.Username = username;
            decimal tempTotal = 0;
            foreach (var item in Products)
            {
                tempTotal += item.Quantity * item.ProductListing.Price;
            }
            this.Total = tempTotal;

        }

    }
}
