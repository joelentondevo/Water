using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.BusinessObjects.Interfaces
{
    public interface IBOFactory
    {
        IBasketBO CreateBasketBO();

        ICorrespondenceBO CreateCorrespondenceBO();

        ILibraryBO CreateLibraryBO();

        IOrderBO CreateOrderBO();

        ISecurityBO CreateSecurityBO();

        IStoreBO CreateStoreBO();

        ISystemBO CreateSystemBO();

    }
}
