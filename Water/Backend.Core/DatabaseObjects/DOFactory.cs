using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.DatabaseObjects
{
    internal class DOFactory : IDOFactory
    {
        public IStoreDO CreateStoreDO()
        {
            return new StoreDO();
        }
        public ISecurityDO CreateSecurityDO()
        {
            return new SecurityDO();
        }
    }
 }

