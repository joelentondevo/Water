using Backend.Core.BusinessObjects;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Mvc;
using Backend.API.Models;

namespace Backend.API.Controllers
{
    public class SecurityController : Controller
    {
        [HttpPost("AuthenticationAttempt")]
            
            public IActionResult AuthenticationAttempt(AuthenticationDetailsModel authenticationDetailsModel)
        {
            bool isValidAttempt = new SecurityBO().ValidateAuthenticationDetails(authenticationDetailsModel.Username, authenticationDetailsModel.Password);
            if (isValidAttempt)
            {
                return Ok("Authentication successful");
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
    }
}

