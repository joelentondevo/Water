using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {
        ICheckoutActivityHandler _checkoutActivityHandler;

        public CheckoutController(ICheckoutActivityHandler checkoutActivityHandler)
        {
            _checkoutActivityHandler = checkoutActivityHandler;
        }

        [Authorize]
        [HttpPost("PlaceOrder")]
        public IActionResult Checkout()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _checkoutActivityHandler.Checkout(userId);
                return Ok("Order is being processed");
            }
            catch
            {
                return BadRequest("Order Processing Failed");
            }
        }
    }
}
