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
            var getAlllocation = await _locationService.GetLocation();
            if (getAlllocation != null)
            {
                return Ok(getAlllocation);
            }
            else
            {
                return BadRequest("No location Exist.");
            }
        }

        [HttpPost("AddLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Addlocation(string locationName, int StatusId)
        {
            Location location = new Location();
            location.LocationName = locationName;
            location.StatusId = StatusId;
            bool statusSuccess = await _locationService.AddLocation(location);
            if (statusSuccess)
            {
                return Ok("Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
        [HttpPut("UpdateLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(string locationName, int statusId, int locationId)
        {
            Location location = new Location();
            location.LocationID = locationId;
            location.LocationName = locationName;
            location.StatusId = statusId;
            bool locationSuccess = await _locationService.UpdateLocation(location);
            if (locationSuccess)
            {
                return Ok("Updated Succesful");
            }
            else
            {
                return BadRequest("Not Succesful");
            }
        }
        [HttpDelete("DeleteLocation")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deletelocation(int locationId)
        {

            bool statusSuccess = await _locationService.DeleteAsync(locationId);
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
