using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Core;
using Backend.Core.EntityObjects;
using Backend.Core.BusinessObjects;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.DatabaseObjects;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreBO _storeBO;
        public StoreController(IStoreBO storeBO)
        {
            _storeBO = storeBO;
        }

        [HttpGet(Name = "GetGames")]
        public List<ProductListingEO> GetAllProductListings()
        {
            return _storeBO.GetFullProductList();
        }
    }
}
