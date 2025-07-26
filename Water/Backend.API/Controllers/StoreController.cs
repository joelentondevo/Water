using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core;
using Backend.Core.EntityObjects;
using Backend.Core.BusinessObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly StoreBO _storeBO;
        public StoreController(IDOFactory dOFactory)
        {
            _storeBO = new StoreBO(dOFactory);
        }

        [HttpGet(Name = "GetGames")]
        public List<ProductListingEO> GetAllProductListings()
        {
            return _storeBO.GetFullProductList();
        }
    }
}
