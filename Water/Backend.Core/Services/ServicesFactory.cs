using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Services.Interfaces;

namespace Backend.Core.Services
{
    internal class ServicesFactory : IServicesFactory
    {
        public IJWTService CreateJWTService()
        {
            return new JWTService();
        }
    }
}
