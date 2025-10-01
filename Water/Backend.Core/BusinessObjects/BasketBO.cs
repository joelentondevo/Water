using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.EntityObjects;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.Services.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class BasketBO : IBasketBO
    {
        IDOFactory _dOFactory;
        IBasketDO _basketDO;
        IServicesFactory _servicesFactory;
        ITaskService _taskService;

        public BasketBO(IDOFactory dOFactory, IServicesFactory servicesFactory)
        {
            _dOFactory = dOFactory;
            _servicesFactory = servicesFactory;
            _basketDO = _dOFactory.CreateBasketDO();
            _taskService = _servicesFactory.CreateTaskService();
        }
        public void GenerateUserBasket(int userID)
        {
            _basketDO.GenerateUserBasket(userID);
        }

        public bool AddProductToBasket(int userId, int itemId, int quantity)
        {
            return _basketDO.AddProductToBasket(userId, itemId, quantity);
        }

        public bool RemoveItemFromBasket(int userId, int itemId)
        {
            return _basketDO.RemoveProductFromBasket(userId, itemId);
        }

        public bool ClearUserBasket(int userId)
        {
            return _basketDO.ClearUserBasket(userId);
        }

        public List<BasketItemEO> GetBasketItems(int userId)
        {
            List<BasketEntryEO> basketList = _basketDO.GetBasketItems(userId);
            List<BasketItemEO> list = new List<BasketItemEO>();
            StoreBO storeBO = new StoreBO(_dOFactory);
            foreach (var item in basketList)
            {
                ProductListingEO productListing = storeBO.GetProductListing(item.ProductID);
                if (productListing == null)
                {
                    continue; // Skip if product listing is not found
                } else
                {
                    list.Add(new BasketItemEO(productListing, item.Quantity));
                }
            }
            return list;
        }

        public void RaiseGenerateUserBasketTask(int userId)
        {
            string taskdata = _taskService.SerializeTaskData(userId);
            TaskEO newTask = new TaskEO("Basket", "GenerateUserBasket", taskdata, DateTime.Now, 5);
            _taskService.ScheduleTask(newTask);
        }

        public void RaiseClearBasketTask(int userId)
        {
            string taskdata = _taskService.SerializeTaskData(userId);
            TaskEO newTask = new TaskEO("Basket", "ClearUserBasket", taskdata, DateTime.Now, 5);
            _taskService.ScheduleTask(newTask);
        }
    }
}
