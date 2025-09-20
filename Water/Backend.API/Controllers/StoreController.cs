using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreActivityHandler _storeActivityHandler;
        private readonly ICheckoutActivityHandler _checkoutActivityHandler;
        public StoreController(IStoreActivityHandler storeActivityHandler)
        {
            _storeActivityHandler = storeActivityHandler;
        }

        [HttpGet("GetFullProductsList")]
        public List<ProductListingEO> GetAllProductListings()
        {
            return _storeActivityHandler.GetFullProductList();
        }

        [HttpGet("GetFilteredProductsList")]
        public List<ProductListingEO> GetFilteredProductListings(string nameSearch)
        {
            return _storeActivityHandler.GetFullProductList();
        }

    }
}
