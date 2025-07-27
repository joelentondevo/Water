using Backend.Core.BusinessObjects;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Mvc;
using Backend.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly ISecurityBO _securityBO;
        public SecurityController(ISecurityBO securityBO)
        {
            _securityBO = securityBO;
        }


        [HttpPost("AuthenticationAttempt")]
            
            public IActionResult AuthenticationAttempt(AuthenticationDetailsModel authenticationDetailsModel)
        {
            string AuthenticationResponse = _securityBO.ValidateAuthenticationDetails(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
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
        public IActionResult RegisterAuthenticationDetails(AuthenticationDetailsModel authenticationDetailsModel) 
        { 
            bool AuthenticationDetailsAdded = _securityBO.AddAuthenticationDetails(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
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

