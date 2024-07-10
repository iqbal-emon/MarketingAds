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
        public async Task<IActionResult> AddProduct(string Title, string Description, decimal Price, int CategoryID, int UserID, int LocationID, string conditon, string imagePath)
        {
            Listing listing = new Listing();
            listing.Title= Title;
            listing.Description= Description;
            listing.Price= Price;
            listing.CategoryID= CategoryID;
            listing.UserID= UserID;
            listing.LocationID= LocationID;
            listing.Condition = conditon;
            Listing? productSuccess = await _productService.AddProduct(listing, imagePath);
            if (productSuccess!=null)
            {
                return Ok(productSuccess);
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }

        [HttpPost("single")]
        public async Task<IActionResult> UploadSingleFile(IFormFile file)
        {
            // Check if file is null
            if (file == null || file.Length == 0)
                return BadRequest("File not selected or empty.");

            // Process the file (e.g., save it to a specific location)
            var filePath = Path.Combine("wwwroot", "uploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Optionally, return a response or additional data
            return Ok(new { filePath });
        }


    }
}
