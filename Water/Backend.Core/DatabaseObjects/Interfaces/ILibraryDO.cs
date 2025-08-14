using Backend.Core.EntityObjects;
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
        bool AddProductToUserLibrary(int userID, int productID, string productKey);
        bool RemoveProductFromUserLibrary(int userID, int productID);
        List<LibraryProductEO> GetLibraryProductsByUserId(int userID);
    }
}
