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
        bool AddProductToUserLibrary(int userID, int productID);
        bool RemoveProductFromUserLibrary(int userID, int productID);
        List<ProductEO> GetLibraryProductsByUserId(int userID);
    }
}
