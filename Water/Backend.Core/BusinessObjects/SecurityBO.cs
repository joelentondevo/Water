using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using BCrypt.Net;
using Backend.Core.DatabaseObjects;

namespace Backend.Core.BusinessObjects
{
    public class SecurityBO
    {
        IDOFactory _dOFactory;
        ISecurityDO _securityDO;    

        public SecurityBO()
        {
            _dOFactory = new DOFactory();
            _securityDO = _dOFactory.CreateSecurityDO();    
        }

    }
}
