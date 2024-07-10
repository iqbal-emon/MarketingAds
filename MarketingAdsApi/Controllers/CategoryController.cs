using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IConfiguration _configuration;

        public CategoryController(CategoryService categoryService, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _configuration = configuration;
        }

        [HttpGet("GetCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategory()
        {
            var categorySuccess = await _categoryService.GetCategory();
            try
            {

            if (categorySuccess != null)
            {
                return Ok(categorySuccess);
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

        [HttpPost("AddCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            try { 
        
            Category categorySuccess = await _categoryService.AddCategory(category);
            if (categorySuccess != null)
            {
                return Ok(categorySuccess);
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
        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(Category category)
        {
            try { 
            Category categorySuccess = await _categoryService.updatedateCategory(category);
            if (categorySuccess!=null)
            {
                return Ok(category);
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
        [HttpDelete("DeleteCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            
            try { 
            Category categorySuccess = await _categoryService.deleteAsync(CategoryId);
            if (categorySuccess!=null)
            {
                return Ok(categorySuccess);
            }
            else
            {
                return BadRequest(new { message = "Not Successful" });
            }
            }
            catch(Exception ex)
            {
                return StatusCode(500,new { message = ex.Message });
            }
        }



    }
}
