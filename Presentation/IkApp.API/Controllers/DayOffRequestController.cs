using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Application.Services;
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
        private readonly INotificationService _notificationService;
        private readonly IAppUserService _appUserService;
        private readonly IDayOffService _dayOffService;

        public DayOffRequestController(IDayOffRequestService dayOffRequestService, IMapper mapper, INotificationService notificationService, IAppUserService appUserService, IDayOffService dayOffService)
        {
            _dayOffRequestService = dayOffRequestService;
            _mapper = mapper;
            _notificationService = notificationService;
            _appUserService = appUserService;
            _dayOffService = dayOffService;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("AddDayOffRequest")]
        public async Task<IActionResult> AddDayOffRequest(RequestForDayOff requestForDayOff)
        {
            var dayOff = _mapper.Map<DayOffRequest>(requestForDayOff);
            try
            {
                _dayOffRequestService.Add(dayOff);
                var user = await _appUserService.GetByIdAsync(dayOff.UserId);
                _notificationService.Add(new Notification
                {
                    NotificationTitle = "İzin Talebi",
                    NotificationDetail = $"{user.FirstName} {user.LastName} İzin talep ediyor",
                    Status = false,
                    UserId = user.ManagerId
                });
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(201);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult GetDayOffRequest(string userId)
        {
            var dayOffRequests = _dayOffRequestService.Where(x => x.UserId == userId);
            var dayOffRequestDtos = _mapper.Map<List<DayOffRequestDTO>>(dayOffRequests);
            return Ok(dayOffRequestDtos);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public async Task<IActionResult> PermissionReject(PermissionRejectModel model)
        {
            try
            {
                var dayOffRequest = await _dayOffRequestService.GetByIdAsync(model.ID);
                dayOffRequest.Status = model.status;
                dayOffRequest.Approval = model.Approval;
                _dayOffRequestService.Update(dayOffRequest);
                if (dayOffRequest.Approval == true)
                {
                    var user = await _appUserService.GetByIdAsync(dayOffRequest.UserId);
                    var dayOff = await _dayOffService.GetByIdAsync(user.DayOff.ID);
                    var remainingDayOff = dayOff.RemainingDayOff;
                    var dayOffNumber = dayOffRequest.DayOffNumber;
                    dayOff.RemainingDayOff = remainingDayOff - dayOffNumber;
                    _dayOffService.Update(dayOff);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("PermissionRequests")]
        public async Task<IActionResult> PermissionRequests(string userId)
        {
            var permissionRequests = _dayOffRequestService.Where(x => x.User.ManagerId == userId && x.Status == false).ToList();
            foreach (var item in permissionRequests)
            {
                var userDto = await _appUserService.GetByIdAsync(item.UserId);
                var user = _mapper.Map<AppUser>(userDto);
                item.User = user;
            }
            var permissionRequestDtos = _mapper.Map<List<DayOffRequestDTO>>(permissionRequests);
            return Ok(permissionRequestDtos);
        }
    }
}
