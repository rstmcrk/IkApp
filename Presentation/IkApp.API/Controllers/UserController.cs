using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace IkApp.API.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(AppUserForRegisterModel userModel, string roleName)
        {
            if (userModel == null && userModel.Password == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _appUserService.RegisterUser(userModel,roleName);
            }
            return StatusCode(201);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AppUserForLoginModel loginUser)
        {
            if (!await _appUserService.ValidateUser(loginUser))
                return Unauthorized();
            return Ok(new
            {
                Token = await _appUserService.CreateToken()
            });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel passwordMode)
        {
            var success = await _appUserService.ChangePaaword(passwordMode);

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _appUserService.GetUsers();

            return Ok(users);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _appUserService.GetByIdAsync(id);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return new JsonResult(user, options);
        }
    }
}
