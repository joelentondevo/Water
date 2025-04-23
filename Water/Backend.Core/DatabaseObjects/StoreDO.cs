using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects
{
    internal class StoreDO : BaseDO
    {
        internal List<ProductListingEO> GetStoreListings()
        {
            List<ProductListingEO> productList = new List<ProductListingEO>();
            DataSet productRecords = RunSP_DS("p_GetMenu_f");
            foreach (DataRow row in productRecords.Tables[0].Rows)
            {
                productList.Add(new ProductListingEO
                {
                    Id = (int)row["ID"],
                    Product = new ProductEO((int)row["ProductID"],
                                             null,
                                             (int)0),
                    Price = (decimal)row["Price"],
                    StartTime = (DateTime)row["StartTime"],
                    EndTime = (DateTime)row["EndTime"],
                });
            }
            return productList;
        }
    }
}
