using Backend.Core.DatabaseObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects
{
    internal class SystemDO : BaseDO, ISystemDO
    {
        public DateTime GetSystemDate() 
        { 
            DataSet dataSet = RunSP_DS("p_GetSystemInfo_f"); 
            DateTime SystemDate = (DateTime)dataSet.Tables[0].Rows[0]["SystemDate"];
            return SystemDate;
        }
    }
}
