using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface ILibraryDO
    {
        bool AddProductToUserLibrary(int userID, int productID);
        bool RemoveProductFromUserLibrary(int userID, int productID);
        DataSet GetLibraryProductsByUserId(int userID);
        bool ValidateProductKey(string productKey, int userID);
        bool RegisterProductKey(string productKey, int userID);
    }
}
