using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Application.DTOs
{
    public record AppUserDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
