using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IConfiguration _configuration;

        public ProductController(ProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        [HttpGet("GetProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProduct()
        {
            var getAllProduct = await _productService.GetProduct();
            if (getAllProduct != null)
            {
                return Ok(getAllProduct);
            }
            else
            {
                return BadRequest("No Product Exist.");
            }
        }

        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(string Title, string Description, decimal Price, int CategoryID, int UserID, string Location, string conditon, IFormFile imageFile)
        {
            Listing listing = new Listing();
            listing.Title= Title;
            listing.Description= Description;
            listing.Price= Price;
            listing.CategoryID= CategoryID;
            listing.UserID= UserID;
            listing.Location= Location;
            listing.Condition = conditon;
            bool productSuccess = await _productService.AddProduct(listing, imageFile);
            if (productSuccess)
            {
                return Ok("Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
    }
}
