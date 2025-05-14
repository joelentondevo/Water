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
    public class StoreDO : BaseDO, IStoreDO
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
                        Product = new ProductEO(row.Field<int>("ProductID"), null, 0),
                        Price = row.Field<decimal>("Price"),
                        StartTime = row.Field<DateTime>("StartTime"),
                        EndTime = row.Field<DateTime>("EndTime"),
                    });
                }
            }

            return productList;
        }
    }
}
