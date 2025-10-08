using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.DatabaseObjects
{
    public class DOFactory : IDOFactory
    {
        public IStoreDO CreateStoreDO()
        {
            return new StoreDO();
        }
        public ISecurityDO CreateSecurityDO()
        {
            return new SecurityDO();
        }
        public IBasketDO CreateBasketDO()
        {
            return new BasketDO();
        }
        public ILibraryDO CreateLibraryDO()
        {
            return new LibraryDO();
        }

        public ITaskDO CreateTaskDO()
        {
            return new TaskDO();
        }
        public IOrderDO CreateOrderDO()
        {
            return new OrderDO();
        }
        public ISystemDO CreateSystemDO()
        {
            return new SystemDO();
        }
    }
 }

