using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActitvityHandlers
{
    public class StoreActivityHandler : IStoreActivityHandler
    {
        IStoreBO _storeBO;
        IBasketBO _basketBO;
        ILibraryBO _libraryBO;

        public StoreActivityHandler(IStoreBO storeBO, IBasketBO basketBO, ILibraryBO libraryBO)
        {
            _storeBO = storeBO;
            _basketBO = basketBO;
            _libraryBO = libraryBO;
        }
    }
}
