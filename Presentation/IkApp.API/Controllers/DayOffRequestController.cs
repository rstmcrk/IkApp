using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Domain.Entities;
using IkApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffRequestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDayOffRequestService _dayOffRequestService;

        public DayOffRequestController(IDayOffRequestService dayOffRequestService, IMapper mapper)
        {
            _dayOffRequestService = dayOffRequestService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("AddDayOffRequest")]
        public IActionResult AddDayOffRequest(RequestForDayOff requestForDayOff)
        {
            var dayOff = _mapper.Map<DayOffRequest>(requestForDayOff);
            _dayOffRequestService.Add(dayOff);
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult GetDayOffRequest(string userId)
        {
            var dayOffRequests = _dayOffRequestService.Where(x => x.UserId == userId);
            var dayOffRequestDtos = _mapper.Map<List<DayOffRequestDTO>>(dayOffRequests);
            return Ok(dayOffRequestDtos);
        }
    }
}
