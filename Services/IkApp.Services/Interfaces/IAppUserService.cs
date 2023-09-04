using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.Services
{
    public interface IAppUserService : IService<AppUser>
    {
        Task<List<AppUserDTO>> GetUsers();
        Task<IdentityResult> RegisterUser(AppUserForRegisterModel userModel, string roleName);
        Task<bool> ValidateUser(AppUserForLoginModel loginUser);
        Task<bool> ChangePaaword(ChangePasswordModel passwordModel);
        Task<string> CreateToken();
        Task<AppUserDTO> GetByIdAsync(string id);
        Task<AppUserDTO> GetUserForUserName(string userName);

    }
}
