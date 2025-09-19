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

        [Authorize]
        [HttpPost("PlaceOrder")]
        public IActionResult Checkout()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _storeActivityHandler.Checkout(userId);
                return Ok("Order is being processed");
            }
            catch
            {
                return BadRequest("Order Processing Failed");
            }

        }

    }
}
