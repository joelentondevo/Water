using Backend.Core.BusinessObjects;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Mvc;
using Backend.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        [HttpPost("AuthenticationAttempt")]
            
            public IActionResult AuthenticationAttempt(AuthenticationDetailsModel authenticationDetailsModel)
        {
            string AuthenticatedTokenString = new SecurityBO().LoginAttempt(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
            if (AuthenticatedTokenString != null)
            {
                return Ok(AuthenticatedTokenString);
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }
        [HttpPost("RegisterUser")]
        public IActionResult RegisterAuthenticationDetails(AuthenticationDetailsModel authenticationDetailsModel) 
        { 
            bool AuthenticationDetailsAdded = new SecurityBO().AddAuthenticationDetails(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
            if (AuthenticationDetailsAdded)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest("User registration failed");
            }
        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult GetProtectedData()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(new { Message = "Access granted!", UserId = userId });
        }
    }
}

