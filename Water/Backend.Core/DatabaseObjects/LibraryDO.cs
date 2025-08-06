using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;


namespace Backend.Core.DatabaseObjects
{
    internal class LibraryDO : BaseDO, ILibraryDO
    {
        public bool AddProductToUserLibrary(int userID, int productID)
        {
            return RUNSP_Bool("p_AddProductToUser_f",
                ("@UserID", userID),
                ("@ProductID", productID));
        }
        public bool RemoveProductFromUserLibrary(int userID, int productID)
        {
            return RUNSP_Bool("p_RemoveProductFromUser_f",
                ("@UserID", userID),
                ("@ProductID", productID));
        }
        public DataSet GetLibraryProductsByUserId(int userID)
        {
            return RunSP_DS("p_GetLibraryProductsByUserId_f",
                ("@UserID", userID));
        }
        public bool ValidateProductKey(string productKey, int userID)
        {
            return false;
        }

        public bool RegisterProductKey(string productKey, int userID)
        {
            return false;
        }
    }
}
