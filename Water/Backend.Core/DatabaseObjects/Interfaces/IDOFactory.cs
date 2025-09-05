using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface IDOFactory
    {
        IStoreDO CreateStoreDO();
        ISecurityDO CreateSecurityDO();
        IBasketDO CreateBasketDO();
        ILibraryDO CreateLibraryDO();

        ITaskDO CreateTaskDO();
    }
}
