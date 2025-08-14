using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;


namespace Backend.Core.DatabaseObjects
{
    internal class LibraryDO : BaseDO, ILibraryDO
    {
        public bool AddProductToUserLibrary(int userID, int productID, string productKey)
        {
            return RUNSP_Bool("p_AddProductToUser_f",
                ("@UserID", userID),
                ("@ProductID", productID),
                ("@ProductKey", productKey));
        }
        public bool RemoveProductFromUserLibrary(int userID, int productID)
        {
            return RUNSP_Bool("p_RemoveProductFromUser_f",
                ("@UserID", userID),
                ("@ProductID", productID));
        }
        public List<LibraryProductEO> GetLibraryProductsByUserId(int userID)
        {
            List<LibraryProductEO> libraryProductList = new List<LibraryProductEO>();
            DataSet dataSet = RunSP_DS("p_GetLibraryProductsByUserId_f",
                ("@UserID", userID));

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    libraryProductList.Add(new LibraryProductEO(
                        new ProductEO(
                            row.Field<int>("ProductID"),
                            row.Field<string>("Name"),
                            row.Field<int>("Type")),
                        row.Field<string>("ProductKey"),
                        row.Field<DateTime>("DateAdded")));
                }
            }
            return libraryProductList;

        }
    }
}
