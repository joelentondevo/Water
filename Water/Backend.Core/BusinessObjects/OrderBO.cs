using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.Core.BusinessObjects
{
    public class OrderBO : IOrderBO
    {
        private readonly IDOFactory _dOFactory;
        private readonly IOrderDO _orderDO;

        public OrderBO(IDOFactory dOFactory)
        {
            _dOFactory = dOFactory;
            _orderDO = _dOFactory.CreateOrderDO();
            
        }
        public bool CreateOrder(OrderMetaDataEO orderData)
        {
            return _orderDO.AddOrderEntry(orderData);
        }
    }
}
