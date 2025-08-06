using Microsoft.AspNetCore.Mvc;
using Backend.Core.BusinessObjects.Interfaces;


namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryBO _libraryBO;

        public LibraryController(ILibraryBO libraryBO)
        {
            _libraryBO = libraryBO;
        }

        //public IActionResult AddProductToUserLibrary()
        //{
        //    return Ok("Product Addded");
        //}

        //public IActionResult RemoveProductFromUserLibrary()
        //{
        //    return Ok("Product Removed");
        //}

        //public IActionResult GetLibraryProductsByUserId()
        //{
            
        //    return Ok();
        //}



    }
}

