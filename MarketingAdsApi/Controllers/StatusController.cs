using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;
        private readonly IConfiguration _configuration;

        public StatusController(StatusService statusService, IConfiguration configuration)
        {
            _statusService = statusService;
            _configuration = configuration;
        }

        [HttpGet("GetStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStatus()
        {
            var getAllStatus = await _statusService.GetStatus();
            if (getAllStatus != null)
            {
                return Ok(getAllStatus);
            }
            else
            {
                return BadRequest("No Status Exist.");
            }
        }

        [HttpPost("AddStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStatus(string StatusName, string ShortForm)
        {
            Status status = new Status();
            status.Name = StatusName;
            status.ShorForm = ShortForm;
          bool statusSuccess=await _statusService.AddStatus(status);
            if (statusSuccess)
            {
                return Ok("Succesful");
            }
            else {
             return BadRequest("Not Succesful");
            }
        }
        [HttpPut("UpdateStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(Status status)
        {

            bool statusSuccess = await _statusService.updatedateStatus(status);
            if (statusSuccess)
            {
                return Ok("Updated Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
        [HttpDelete("DeleteStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStatus(int StatusId)
        {

            bool statusSuccess = await _statusService.deleteAsync(StatusId);
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