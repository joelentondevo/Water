using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;
using Backend.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Backend.Core.BusinessObjects
{
    public class LibraryBO : ILibraryBO
    {
        private readonly IDOFactory _dOFactory;
        private readonly ILibraryDO _libraryDO;
        private readonly IServicesFactory _servicesFactory;
        private readonly IProductKeyService _productKeyService;
        private readonly ITaskService _taskService;

        public LibraryBO(IDOFactory dOFactory, IServicesFactory servicesFactory)
        {
            _dOFactory = dOFactory;
            _servicesFactory = servicesFactory;
            _libraryDO = _dOFactory.CreateLibraryDO();
            _productKeyService = _servicesFactory.CreateProductKeyService();
            _taskService = _servicesFactory.CreateTaskService();
        }

        public bool AddProductToUserLibrary(int userId, int productId, string productKey = null)
        {
            try
            {
                if (productKey == null)
                {
                    productKey = _productKeyService.GenerateProductKey(16, 4);
                }
                _libraryDO.AddProductToUserLibrary(userId, productId, productKey);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product to user library: {ex.Message}");
                return false;
            }
        }

        public string GenerateProductKey(int length, int intervalLength)
        {
            return _productKeyService.GenerateProductKey(length, intervalLength);
        }

        public bool RemoveProductFromUserLibrary(int userId, int productId)
        {
            return _libraryDO.RemoveProductFromUserLibrary(userId, productId);
        }
        public List<LibraryProductEO> GetLibraryProductsByUserId(int userId)
        {
            return _libraryDO.GetLibraryProductsByUserId(userId);
        }

        public void RaiseAddProductToLibraryTask(AddProductToLibraryEO addProductToLibraryEO)
        {
            string libraryTaskData = _taskService.SerializeTaskData(addProductToLibraryEO);
            TaskEO libraryTask = new TaskEO("Library", "AddProductToLibrary", libraryTaskData, DateTime.Now, 5);
            _taskService.ScheduleTask(libraryTask);
        }
    }
}
