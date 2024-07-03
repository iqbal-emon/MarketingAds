using MarketingAds.Data;
using MarketingAds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarketingAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetData : ControllerBase
    {
        private readonly Marketing _context;

        public GetData(Marketing context)
        {
            _context = context;
        }

        // GET: api/GetData/Users
        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<Category>>> GetUsers()
        {
            return await _context.Categories.ToListAsync();
        }


    }
}
