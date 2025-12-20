using Backend.ActivityLayer.ActivityHandlers.Interfaces;
using Backend.API.Models;
using Backend.Core.EntityObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
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
        [HttpPost("AddProductListing")]
        public IActionResult AddProductListing(ProductListingEO productListingToAdd)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
                if (userRole == "Admin")
                {
                    _storeActivityHandler.AddProductListing(productListingToAdd);
                    return Ok("Product Listing Added Successfully");
                } else 
                {
                    return Unauthorized("User does not have correct authorisation");
                }
        }

        [Authorize]
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] AddProductModel productToAdd)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole == "Admin")
            {
                ProductEntryEO product = new ProductEntryEO(productToAdd.Name, productToAdd.Type);
                _storeActivityHandler.AddProduct(product);
                return Ok("Product Added Successfully");
            }
            else
            {
                return Unauthorized("User does not have correct authorisation");
            }
        }
    }
}
