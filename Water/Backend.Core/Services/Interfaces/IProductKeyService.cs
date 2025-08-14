using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services.Interfaces
{
    public interface IProductKeyService
    {
        bool ValidateProductKey(string productKey,int productId);

        string GenerateProductKey(int productKeyLength, int intervalLength);

        bool RegisterProductKey(string productKey, int productId);


    }
}
