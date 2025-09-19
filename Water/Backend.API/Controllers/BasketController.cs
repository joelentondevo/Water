using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Core.EntityObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketActivityHandler _basketActivityHandler;

        public BasketController(IBasketActivityHandler basketActivtyHandler)
        {
            _basketActivityHandler = basketActivtyHandler;
        }

        [Authorize]
        [HttpGet(Name = "GetBasket")]
        public List<BasketItemEO> GetBasket()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _basketActivityHandler.GetBasketItemsByUserId(int.Parse(userId));
            return response;
        }
        [Authorize]
        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket(int productId, int quantity)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var success = _basketActivityHandler.AddProductToUserBasket(int.Parse(userId), productId, quantity);
            if (success)
            {
                return Ok($"Product with ID {productId} added to the basket with quantity {quantity}.");
            }
            else
            {
                return BadRequest("Failed to add product to the basket.");
            }
        }
        [Authorize]
        [HttpDelete("RemoveFromBasket")]
        public IActionResult RemoveFromBasket(int productId)
        {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var success = _basketActivityHandler.RemoveProductFromUserBasket(int.Parse(userId), productId);
            if (success)
            {
                return Ok($"Product with ID {productId} removed from the basket.");
            }
            else
            {
                return BadRequest("Failed to remove product from the basket.");
            }
        }
        [Authorize]
        [HttpPost("GenerateUserBasket")]
        public IActionResult GenerateUserBasket()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != null)
            {
                _basketActivityHandler.GenerateUserBasket(userId);
                return Ok("User basket generated successfully.");
            }
            else
            {
                return BadRequest("User ID not found in the token.");
            }
        }
    }
}
