using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core;
using Backend.Core.EntityObjects;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreActivityHandler _storeActivityHandler;
        public StoreController(IStoreActivityHandler storeActivityHandler)
        {
            _storeActivityHandler = storeActivityHandler;
        }

        [HttpGet(Name = "GetGames")]
        public List<ProductListingEO> GetAllProductListings()
        {
            return _storeActivityHandler.GetFullProductList();
        }

    }
}
