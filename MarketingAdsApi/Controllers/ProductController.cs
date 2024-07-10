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
            try
            {
            var getAllProduct = await _productService.GetProduct();

           
            if (getAllProduct != null)
            {
                return Ok(getAllProduct);
            }
                else
                {
                    return BadRequest(new { message = "Not Successful" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });

            }
        }

        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(Listing listing,string imagePath)
        {
            try
            {
            Listing? productSuccess = await _productService.AddProduct(listing, imagePath);

            if (productSuccess!=null)
            {
                return Ok(productSuccess);
            }
                else
                {
                    return BadRequest(new { message = "Not Successful" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });

            }
        }
        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(Listing listing)
        {
            try
            {
            Listing? productSuccess = await _productService.UpdateProduct(listing);

                if (productSuccess != null)
                {
                    return Ok(productSuccess);
                }
                else
                {
                    return BadRequest(new { message = "Not Successful" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });

            }
        }


    }
}
