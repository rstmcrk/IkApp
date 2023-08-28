using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using IkApp.Cache;
using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Services.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cacheManager;
        private readonly IConfiguration _config;
        private readonly ILoggerService _logger;
        private AppUser _user;

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, ICacheManager cacheManager, IConfiguration config, ILoggerService logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cacheManager = cacheManager;
            _config = config;
            _logger = logger;
        }

        public void Add(AppUser entity)
        {
             _cacheManager.Remove("users");
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

        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSiginCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public IQueryable<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUserDTO>> GetUsers()
        {
            var usersDTOs = await _cacheManager.GetAsync<List<AppUserDTO>>("users", () =>
            {
                var users = _userManager.Users
                    .Include(u => u.Address) 
                    .Include(u => u.Department)
                    .Include(u => u.Task)
                    .ToList();
                return _mapper.Map<List<AppUserDTO>>(users);

            }, new TimeSpan(0, 10, 0));



            return usersDTOs;
        }

        public async Task<IdentityResult> RegisterUser(AppUserForRegisterModel userModel, string roleName)
        {
            _cacheManager.Remove("users");
            _mapper.Map<DayOff>(userModel.DayOff);
            _mapper.Map<Address>(userModel.Address);
            _mapper.Map<Department>(userModel.Department);
            _mapper.Map<Task>(userModel.Task);
            var user = _mapper.Map<AppUser>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }

            return result;
        }

        public void Remove(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUser(AppUserForLoginModel loginUser)
        {
            _user = await _userManager.FindByNameAsync(loginUser.UserName);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginUser.Password);
            _logger.LogInfo($"{_user} doğrulandı.");
            return result;
        }

        public IQueryable<AppUser> Where(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
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
                new Claim("UserId", _user.Id),
                new Claim("UserName", _user.UserName),
                new Claim("FirstName", _user.FirstName),
                new Claim("LastName", _user.LastName),
                new Claim("Email", _user.Email),
                new Claim("StartDateOfWork", _user.StartDateOfWork.ToString())
                

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

        public async Task<AppUserDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userInclude = _userManager.Users
                .Include(u => u.Address)
                .Include(u => u.Department)
                .Include(u => u.Task)
                .FirstOrDefault(u => u.Id == user.Id);
            var userDto = _mapper.Map<AppUserDTO>(userInclude);
            return userDto;
        }

        public async Task<AppUserDTO> GetUserForUserName(string userName)
        {
           var user = await _userManager.FindByNameAsync(userName);
           var userDto = _mapper.Map<AppUserDTO>(user);
            return userDto;
        }
    }
}
