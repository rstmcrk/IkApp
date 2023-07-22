using AutoMapper;
using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private AppUser _user;
        public AuthenticationService(UserManager<AppUser> userManager, IConfiguration config, IMapper mapper, ILoggerService logger)
        {
            _userManager = userManager;
            _config = config;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSiginCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<IdentityResult> RegisterUser(AppUserForRegisterModel userModel)
        {
            var user = _mapper.Map<AppUser>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<bool> ValidateUser(AppUserForLoginModel loginUser)
        {
            _user = await _userManager.FindByNameAsync(loginUser.UserName);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginUser.Password);
            _logger.LogInfo($"{_user} doğrulandı.");
            return result;
        }

        public async Task<bool> ChangePaaword(ChangePasswordModel passwordModel)
        {
            var user = await _userManager.FindByNameAsync(passwordModel.UserName);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, passwordModel.CurrentPassword, passwordModel.NewPassword);
            return result.Succeeded;
        }

        private SigningCredentials GetSiginCredentials()
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager
                .GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signinCredentials);
            return tokenOptions;
        }
    }
}
