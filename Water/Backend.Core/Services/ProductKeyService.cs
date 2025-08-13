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
        IDOFactory _dOFactory;
        IProductKeyDO _productKeyDO;

        public ProductKeyService(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
            _productKeyDO = _dOFactory.CreateProductKeyDO();
        }

        public bool ValidateProductKey(string productKey, int productId, string userId)
        {
            string storedProductKey = _productKeyDO.GetProductKeyDetails(productId, userId);
            if (storedProductKey == productKey)
            {
                return true;
            }
            return false;
            
        }

        public string GenerateProductKey(string productKey, int keyLength = 16, int intervalLength = 4)
        {
            char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            Random _random = new Random();

        var productKeyBuilder = new StringBuilder();
            for (int i = 0; i< keyLength; i++)
            {
                productKeyBuilder.Append(_chars[_random.Next()]);
                if (i % intervalLength == 0)
                {
                    productKeyBuilder.Append("-");
                }
            }
            return productKey;
        }

        public bool RegisterProductKey(string productKey,int productId, string userId)
        {
            return _productKeyDO.RegisterProductKey(productKey, productId, userId);
        }
    }
}
