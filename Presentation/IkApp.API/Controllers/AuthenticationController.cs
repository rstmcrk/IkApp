using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(AppUserForRegisterModel userModel)
        {
            if (userModel == null && userModel.Password == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _authenticationService.RegisterUser(userModel);
            }
            return StatusCode(201);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AppUserForLoginModel loginUser)
        {
            if (!await _authenticationService.ValidateUser(loginUser))
                return Unauthorized();
            return Ok(new
            {
                Token = await _authenticationService.CreateToken()
            });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel passwordMode)
        {
            var success = await _authenticationService.ChangePaaword(passwordMode);

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
