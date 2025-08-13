using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface IProductKeyDO
    {

        bool RegisterProductKey(string productKey, int productID, string userID);

        string GetProductKeyDetails(int productID, string userID); 
    }
}
