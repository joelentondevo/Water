using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.Services.Interfaces;

namespace Backend.Core.Services
{
    public class ServicesFactory : IServicesFactory
    {
        private readonly IDOFactory _dOFactory;
        
        public ServicesFactory(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
        }
        public IJWTService CreateJWTService()
        {
            return new JWTService();
        }
        public IProductKeyService CreateProductKeyService()
        {
            return new ProductKeyService(_dOFactory);
        }

        public ITaskService CreateTaskService()
        {
            return new TaskService(_dOFactory);
        }
    }
}
