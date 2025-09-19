using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.Services.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class BOFactory : IBOFactory
    {
        IDOFactory _dOFactory;
        IServicesFactory _servicesFactory;
        public BOFactory(IDOFactory dOFactory, IServicesFactory servicesFactory) {
        _dOFactory = dOFactory;
        _servicesFactory = servicesFactory;
        }

        public IBasketBO CreateBasketBO()
        {
            return new BasketBO(_dOFactory);
        }
        public ICorrespondenceBO CreateCorrespondenceBO()
        {
            return new CorrespondenceBO(_dOFactory, _servicesFactory);
        }
        public ILibraryBO CreateLibraryBO()
        {
            return new LibraryBO(_dOFactory, _servicesFactory);
        }
        public IOrderBO CreateOrderBO()
        {
            return new OrderBO();
        }
        public ISecurityBO CreateSecurityBO()
        {
            return new SecurityBO(_dOFactory, _servicesFactory);
        }
        public IStoreBO CreateStoreBO()
        {
            return new StoreBO(_dOFactory);
        }
    }
}
