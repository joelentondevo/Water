using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services.Interfaces
{
    public interface IProductKeyService
    {
        string GenerateProductKey(int productKeyLength, int intervalLength);

    }
}
