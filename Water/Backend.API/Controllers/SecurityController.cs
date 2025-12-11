using Microsoft.AspNetCore.Mvc;
using Backend.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.ActivityLayer.ActivityHandlers.Interfaces;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly ISecurityActivityHandler _securityActivityHandler;
        public SecurityController(ISecurityActivityHandler securityActivityHandler)
        {
            _securityActivityHandler = securityActivityHandler;
        }


        [HttpPost("AuthenticationAttempt")]
            
            public IActionResult AuthenticationAttempt(AuthenticationDetailsModel authenticationDetailsModel)
        {
            string AuthenticationResponse = _securityActivityHandler.UserLoginAttempt(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
            if (AuthenticationResponse != null)
            {
                return Ok(AuthenticationResponse);
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }
        [HttpPost("RegisterUser")]
        public IActionResult RegisterAuthenticationDetails(AuthenticationDetailsModel authenticationDetailsModel, int role) 
        { 
            bool AuthenticationDetailsAdded = _securityActivityHandler.UserRegistration(authenticationDetailsModel.Username, authenticationDetailsModel.Password, role);
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

