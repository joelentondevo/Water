using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Core.EntityObjects;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        [Authorize]
        [HttpGet(Name = "GetBasket")]
        public List<BasketItemEO> GetBasket()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = new BasketBO().GetBasketItems(int.Parse(userId));
            return response;
        }
        [Authorize]
        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket(int productId, int quantity)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var success = new BasketBO().AddProductToBasket(int.Parse(userId), productId, quantity);
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
                var success = new BasketBO().RemoveItemFromBasket(int.Parse(userId), productId);
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
            var basketBO = new BasketBO();
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId != null)
            {
                basketBO.GenerateUserBasket(userId);
                return Ok("User basket generated successfully.");
            }
            else
            {
                return BadRequest("User ID not found in the token.");
            }
        }
    }
}
