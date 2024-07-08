using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateUserStatus(int UserId,int statusId)
        {
 
            bool statusSuccess = await _userService.StatusChanged(UserId,statusId);
            if (statusSuccess)
            {
                return Ok("Updated Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }

        }
    }
}
