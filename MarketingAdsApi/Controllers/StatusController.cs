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
            try { 
            var getAllStatus = await _statusService.GetStatus();
            if (getAllStatus != null)
            {
                return Ok(getAllStatus);
            }
            else
            {
                    return BadRequest(new { message = "Not Successful" });
            }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });

            }
        }

        [HttpPost("AddStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStatus(Status status)
        {
            try
            {
          Status statusSuccess=await _statusService.AddStatus(status);
                if (statusSuccess != null)
                {
                    return Ok(statusSuccess);
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
        [HttpPut("UpdateStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(Status status)
        {

            try
            {
            Status statusSuccess = await _statusService.updatedateStatus(status);
                if (statusSuccess!=null)
                {
                    return Ok(statusSuccess);
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
        [HttpDelete("DeleteStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStatus(int StatusId)
        {
          
            try
            {
            Status statusSuccess = await _statusService.deleteAsync(StatusId);
                if (statusSuccess != null)
                {
                    return Ok(statusSuccess);
                }
                else
                {
                    return BadRequest( new {message="Not Successful"});
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });

            }
        }






    }
}