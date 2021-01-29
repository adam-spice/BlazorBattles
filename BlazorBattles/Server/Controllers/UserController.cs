﻿using BlazorBattles.Server.Data;
using BlazorBattles.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utilityService;

        public UserController(DataContext context, IUtilityService utilityService)
        {
            _context = context;
            _utilityService = utilityService;
        }



        [HttpGet("GetBananas")]
        public async Task<IActionResult> GetBananas()
        {

            var user = await _utilityService.GetUser();

            return Ok(user.Bananas);
        }

        [HttpPut("Addbananas")]
        public async Task<IActionResult> AddBananas([FromBody] int bananas)
        {
            var user = await _utilityService.GetUser();
            user.Bananas += bananas;
            await _context.SaveChangesAsync();
            return Ok(user.Bananas);

        }
    }
}
