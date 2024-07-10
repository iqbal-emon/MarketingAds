using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarketingAdsLibrary.Services;
using MarketingAds.Models;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ProductService _productService;

        public ImageController(ProductService productService)
        {
            _productService = productService;
        }

        // Upload image
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage( IFormFile image)
        {
            try
            {
             var imagePath=await _productService.SaveImageToServer(image);
                return Ok(imagePath);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{imageName}")]
        public IActionResult DeleteImage(string imageName)
        {
            try
            {
                _productService.DeleteImageFromServer(imageName);
                return Ok("Image deleted successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
