using Backend.Core.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface ILibraryBO
    {
        bool AddProductToUserLibrary(int userID, int productID, string productKey);
        bool RemoveProductFromUserLibrary(int userID, int productID);
        string GenerateProductKey(int length, int intervalLength);
        List<LibraryProductEO> GetLibraryProductsByUserId(int userID);
    }
}
