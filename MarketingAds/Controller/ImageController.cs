using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAds.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IConfiguration _configuration;

        public ImageController(ProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
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
