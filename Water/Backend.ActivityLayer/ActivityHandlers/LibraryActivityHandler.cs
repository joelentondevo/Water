using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers
{
    public class LibraryActivityHandler : ILibraryActivityHandler
    {
        public readonly ILibraryBO _libraryBO;
        public readonly IBOFactory _bOFactory;

        public LibraryActivityHandler(IBOFactory bOFactory)
        {
            _bOFactory = bOFactory;
            _libraryBO = _bOFactory.CreateLibraryBO();
        }

        public bool AddProductToUserLibrary(int userId, int productId, string ProductKey)
        {
            return _libraryBO.AddProductToUserLibrary(userId, productId, ProductKey);
        }
    }
}
