using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.Core.EntityObjects;

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
                UserDetailsEO userDetails = new UserDetailsEO(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value), (string)(User.FindFirst(ClaimTypes.Name)?.Value));
                _checkoutActivityHandler.Checkout(userDetails);
                return Ok("Order is being processed");
            }
            catch
            {
                return BadRequest("Order Processing Failed");
            }
        }
    }
}
