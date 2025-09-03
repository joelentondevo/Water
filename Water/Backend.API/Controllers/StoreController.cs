using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Claims;

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
        [Authorize]
        [HttpPost(Name = "Checkout")]
        public void Checkout()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _storeActivityHandler.Checkout(userId);
        }

    }
}
