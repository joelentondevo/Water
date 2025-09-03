using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services
{
    internal class ProductKeyService : IProductKeyService
    {

        public ProductKeyService(IDOFactory dOFactory)
        {
        }

        public string GenerateProductKey(int keyLength = 16, int intervalLength = 4)
        {
            char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            Random _random = new Random();

        var productKeyBuilder = new StringBuilder();
            for (int i = 0; i< keyLength; i++)
            {
                productKeyBuilder.Append(_chars[_random.Next(_chars.Length)]);
                if (i % intervalLength == 0)
                {
                    productKeyBuilder.Append("-");
                }
            }
            string productKey = productKeyBuilder.ToString();
            return productKey;
        }
    }
}
