using IkApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private readonly IDayOffService _dayOffService;

        public DayOffController(IDayOffService dayOffService)
        {
            _dayOffService = dayOffService;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetDayOff(string id)
        {
            var dayOff = await _dayOffService.GetByUserIdAsync(id);
            return Ok(dayOff);
        }
    }
}
