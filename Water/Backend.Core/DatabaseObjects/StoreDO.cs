using Backend.Core.EntityObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Backend.Core.DatabaseObjects
{
    internal class StoreDO : BaseDO, IStoreDO
    {
        public List<ProductListingEO> GetStoreListings()
        {
            List<ProductListingEO> productList = new List<ProductListingEO>();
            DataSet productRecords = RunSP_DS("p_GetAllStoreItems_f");

            if (productRecords != null && productRecords.Tables.Count > 0 && productRecords.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in productRecords.Tables[0].Rows)
                {
                    productList.Add(new ProductListingEO
                    {
                        Id = row.Field<int>("ID"),
                        Product = GetProduct(row.Field<int>("ProductID")),
                        Price = row.Field<decimal>("Price"),
                        StartTime = row.Field<DateTime>("StartTime"),
                        EndTime = row.Field<DateTime>("EndTime"),
                    });
                }
            }

            return productList;
        }

        public ProductListingEO GetProductListing(int productId)
        {
            ProductListingEO productListing = null;
            DataSet productRecords = RunSP_DS("p_GetStoreItem_f", ("@productId", productId));
            if (productRecords != null && productRecords.Tables.Count > 0 && productRecords.Tables[0].Rows.Count > 0)
            {
                DataRow row = productRecords.Tables[0].Rows[0];
                productListing = new ProductListingEO
                {
                    Id = row.Field<int>("ID"),
                    Product = GetProduct(productId),
                    Price = row.Field<decimal>("Price"),
                    StartTime = row.Field<DateTime>("StartTime"),
                    EndTime = row.Field<DateTime>("EndTime"),
                };
            }
            return productListing;
        }

        public ProductEO GetProduct(int productID)
        {
            ProductEO product = null;
            DataSet productRecord = RunSP_DS("p_GetProduct_f", ("@ProductID", productID));
            if (productRecord != null && productRecord.Tables.Count > 0 && productRecord.Tables[0].Rows.Count > 0)
            {
                DataRow row = productRecord.Tables[0].Rows[0];
                product = new ProductEO(row.Field<int>("ID"), row.Field<string>("ProductName"), row.Field<int>("ProductType"));
            }
            return product;
        }

        public bool AddProductListing(ProductListingEO productListing)
        {
            return RunSP_Bool("p_AddProductListing_i", 
                ("@ProductID", productListing.Product.Id),
                ("@Price", productListing.Price),
                ("@StartTime", productListing.StartTime),
                ("@EndTime", productListing.EndTime));
        }
    }
}
