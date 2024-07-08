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
            var getAllCategory = await _categoryService.GetCategory();
            if (getAllCategory != null)
            {
                return Ok(getAllCategory);
            }
            else
            {
                return BadRequest("No Category Exist.");
            }
        }

        [HttpPost("AddCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(string CategoryName, int StatusId)
        {
            Category category = new Category();
            category.CategoryName = CategoryName;
            category.StatusId = StatusId;
            bool statusSuccess = await _categoryService.AddCategory(category);
            if (statusSuccess)
            {
                return Ok("Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(string categoryName,int statusId,int categoryId)
        {
            Category category=new Category();
            category.CategoryID = categoryId;
            category.CategoryName=categoryName;
            category.StatusId=statusId;
            bool categorySuccess = await _categoryService.updatedateCategory(category);
            if (categorySuccess)
            {
                return Ok("Updated Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
        [HttpDelete("DeleteCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            
            bool statusSuccess = await _categoryService.deleteAsync(CategoryId);
            if (statusSuccess)
            {
                return Ok("Delete Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }



    }
}
