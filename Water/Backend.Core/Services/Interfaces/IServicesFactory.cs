using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services.Interfaces
{
    public interface IServicesFactory
    {
        IJWTService CreateJWTService();

        IProductKeyService CreateProductKeyService();

        ITaskService CreateTaskService();
    }
}
