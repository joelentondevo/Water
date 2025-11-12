using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class SystemBO : ISystemBO
    {
        ISystemDO _systemDO;
        IDOFactory _dOFactory;

        public SystemBO(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
            _systemDO = _dOFactory.CreateSystemDO();
        }

        public DateTime GetSystemDate()
        {
            return _systemDO.GetSystemDate();
        }
    }
}
