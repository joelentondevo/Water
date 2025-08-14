using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core;
using Backend.Core.EntityObjects;
using Backend.Core.BusinessObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreBO _storeBO;
        private readonly IStoreActivityHandler _storeActivityHandler;
        public StoreController(IStoreBO storeBO, IStoreActivityHandler storeActivityHandler)
        {
            _storeBO = storeBO;
            _storeActivityHandler = storeActivityHandler;
        }

        [HttpGet(Name = "GetGames")]
        public List<ProductListingEO> GetAllProductListings()
        {
            return _storeBO.GetFullProductList();
        }
    }
}
