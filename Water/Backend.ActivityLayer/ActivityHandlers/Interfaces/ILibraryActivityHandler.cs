using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers.Interfaces
{
    public interface ILibraryActivityHandler
    {
        bool AddProductToUserLibrary(int userId, int productId, string ProductKey);
    }
}
