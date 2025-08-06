using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.EntityObjects;

namespace Backend.Core.BusinessObjects
{
    public class LibraryBO : ILibraryBO
    {
        private readonly IDOFactory _dOFactory;
        private readonly ILibraryDO _libraryDO;

        public LibraryBO(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
            _libraryDO = _dOFactory.CreateLibraryDO();
        }

        public bool AddProductToUserLibrary(int userID, int productID)
        {
            try
            {
                _libraryDO.AddProductToUserLibrary(userID, productID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product to user library: {ex.Message}");
                return false;
            }
        }

        public bool RemoveProductFromUserLibrary(int userID, int productID)
        {
            return false;
        }
        public List<ProductEO> GetLibraryProductsByUserId(int userID)
        {
            return new List<ProductEO>();
        }
    }
}
