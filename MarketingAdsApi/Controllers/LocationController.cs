using MarketingAds.Models;
using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly IConfiguration _configuration;

        public LocationController(LocationService locationService, IConfiguration configuration)
        {
            _locationService = locationService;
            _configuration = configuration;
        }

        [HttpGet("GetLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Getlocation()
        {
             try
            {
                var getAlllocation = await _locationService.GetLocation();
           

            if (getAlllocation != null)
            {
                return Ok(getAlllocation);
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
        

        [HttpPost("AddLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Addlocation(Location location)
        {
            try
            {
            Location locationSuccess = await _locationService.AddLocation(location);

            if (locationSuccess != null)
            {
                return Ok(locationSuccess);
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
        [HttpPut("UpdateLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            try {
            Location locationSuccess = await _locationService.UpdateLocation(location);
            if (locationSuccess!=null)
            {
                return Ok(locationSuccess);
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
        [HttpDelete("DeleteLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deletelocation(int locationId)
        {

            try
            {
            Location locationSuccess = await _locationService.DeleteAsync(locationId);
                if (locationSuccess != null)
                {
                    return Ok(locationSuccess);
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
