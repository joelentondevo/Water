using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.DatabaseObjects
{
    internal class BasketDO : BaseDO, IBasketDO
    {
        public bool GenerateUserBasket(int userID)
        {
            return RUNSP_Bool("p_GenerateUserBasket_f", ("@UserID", userID));
        }
    }
}
