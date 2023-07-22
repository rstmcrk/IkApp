using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.RequestModels
{
    public record AppUserForLoginModel
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
