using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;

namespace Backend.Core.DatabaseObjects
{
    internal class ProductKeyDO : BaseDO, IProductKeyDO
    {
        public bool RegisterProductKey(string productKey, int productID)
        {
            return true;
        }

        public int GetProductKeyAssociatedProduct(int productID)
        {
            return 0;
        }

    }
}
