using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core.BusinessObjects;
using Microsoft.AspNetCore.Authorization;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        [Authorize]
        [HttpGet(Name = "GetBasket")]
        public IActionResult GetBasket()
        {
            // This method should return the current user's basket.
            // For now, we will return a placeholder response.
            return Ok("This is a placeholder for the user's basket.");
        }
        [Authorize]
        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket(int productId)
        {
            // This method should add a product to the user's basket.
            // For now, we will return a placeholder response.
            return Ok($"Product with ID {productId} added to the basket.");
        }
        [Authorize]
        [HttpDelete("RemoveFromBasket")]
        public IActionResult RemoveFromBasket(int productId)
        {
            // This method should remove a product from the user's basket.
            // For now, we will return a placeholder response.
            return Ok($"Product with ID {productId} removed from the basket.");
        }
    }
}
