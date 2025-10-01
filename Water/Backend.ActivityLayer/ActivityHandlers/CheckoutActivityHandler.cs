using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ActivityLayer.ActivityHandlers
{
    public class CheckoutActivityHandler : ICheckoutActivityHandler
    {
        IBOFactory _bOFactory;
        IBasketBO _basketBO;
        ILibraryBO _libraryBO;
        ICorrespondenceBO _correspondenceBO;
        IOrderBO _orderBO;

        public CheckoutActivityHandler(IBOFactory bOFactory)
        {
            _bOFactory = bOFactory;
            _basketBO = _bOFactory.CreateBasketBO();
            _libraryBO = _bOFactory.CreateLibraryBO();
            _orderBO = _bOFactory.CreateOrderBO();
            _correspondenceBO = _bOFactory.CreateCorrespondenceBO();
        }

        public void Checkout(UserDetailsEO userDetails)
        {
            DateTime orderDate = DateTime.Now;
            List<BasketItemEO> checkoutBasket = _basketBO.GetBasketItems(userDetails.UserID);
            if (checkoutBasket != null)
            {
                OrderMetaDataEO metaDataEO = new OrderMetaDataEO(userDetails.UserID, orderDate, 1);
                int orderId = _orderBO.CreateOrder(metaDataEO);
                OrderDataEO orderData = new OrderDataEO(orderId, metaDataEO, checkoutBasket);
                _orderBO.CreateOrderDetail(orderData);
                foreach (var item in checkoutBasket)
                {
                    AddProductToLibraryEO addProductToLibraryEO = new AddProductToLibraryEO(userDetails.UserID, item.ProductListing.Id, _libraryBO.GenerateProductKey(16, 4));
                    _libraryBO.RaiseAddProductToLibraryTask(addProductToLibraryEO);
                }
                ReceiptDataEO receiptData = new ReceiptDataEO(checkoutBasket, orderDate, userDetails.UserName);
                _correspondenceBO.RaiseReceiptTask(receiptData);
                _basketBO.RaiseClearBasketTask(userDetails.UserID);
            }
        }
    }
}
