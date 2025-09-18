using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.ConfigurationObjects;
using Microsoft.Extensions.Configuration;

namespace Backend.Core.BusinessObjects
{
    public class CorrespondenceBO : ICorrespondenceBO
    {
        public void GenerateReceipt(ReceiptDataEO receiptData)
        {
            var outputConfig = new BackendCoreConfiguration().GetConfig().GetSection("Outputs");
            string filePath = outputConfig["OutputPath"];
            var receipt = new StringBuilder();
            receipt.AppendLine("=== RECEIPT ===");
            receipt.AppendLine("Date: " + receiptData.OrderDate.ToString("yyyy-MM-dd HH:mm"));
            receipt.AppendLine("Customer: " + receiptData.Username);
            receipt.AppendLine("Items:");
            foreach (var product in receiptData.Products)
            {
                receipt.AppendLine("Product: " + product.ProductListing.Product.Name + " --- Quantity: " + product.Quantity + " --- Unit Price: " + product.ProductListing.Price);
            }
            receipt.AppendLine("Total: " + receiptData.Total); 

            File.WriteAllText(filePath, receipt.ToString());
        }
    }
}
