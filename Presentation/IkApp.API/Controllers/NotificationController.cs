using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetNotification(string id)
        {
            var notifications = _notificationService.Where(x => x.UserId == id && x.Status == false);
            var notificationDtos = _mapper.Map<List<NotificationDTO>>(notifications);
            return Ok(notificationDtos);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var notification = await _notificationService.GetByIdAsync(id);

            if (notification == null)
            {
                return NotFound(); 
            }

            notification.Status = true;
            _notificationService.Update(notification);

            return Ok();
        }
    }
}
