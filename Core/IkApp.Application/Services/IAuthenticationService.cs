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
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(AppUserForRegisterModel userModel);
        Task<bool> ValidateUser(AppUserForLoginModel loginUser);
        Task<bool> ChangePaaword(ChangePasswordModel passwordModel);
        Task<string> CreateToken();
    }
}
