using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.ConfigurationObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects
{
    public class CorrespondenceBO : ICorrespondenceBO
    {
        IDOFactory _dOFactory;
        IServicesFactory _servicesFactory;
        ITaskService _taskService;

        public CorrespondenceBO(IDOFactory dOFactory, IServicesFactory servicesFactory)
        {
            _dOFactory = dOFactory;
            _servicesFactory = servicesFactory;
            _taskService = _servicesFactory.CreateTaskService();
        }

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
            string fileName = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string fullPath = Path.Combine(filePath, fileName);

            File.WriteAllText(fullPath, receipt.ToString());
        }

        public void RaiseReceiptTask(ReceiptDataEO receiptData)
        {
            string receiptTaskData = _taskService.SerializeTaskData(receiptData);
            TaskEO receiptTask = new TaskEO("Correspondence", "GenerateOrderReceipt", receiptTaskData, DateTime.Now, 5);
            _taskService.ScheduleTask(receiptTask);
        }
    }
}
