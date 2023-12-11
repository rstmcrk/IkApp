using FluentValidation;
using IkApp.Application.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.Validators.FluentValidation.User
{
    public class LoginUserValidator : AbstractValidator<AppUserForLoginModel>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kullanıcı adını boş geçmeyiniz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen şifreyi boş geçmeyiniz");
        }
    }
}