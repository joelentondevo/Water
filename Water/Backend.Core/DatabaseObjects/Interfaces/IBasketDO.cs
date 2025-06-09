using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DatabaseObjects.Interfaces
{
    public interface IBasketDO
    {
        bool GenerateUserBasket(int UserID);

        bool AddProductToBasket(int UserID, int ProductID, int Quantity);
        bool RemoveProductFromBasket(int UserID, int ProductID);
        bool ClearUserBasket(int UserID);
    }
}
