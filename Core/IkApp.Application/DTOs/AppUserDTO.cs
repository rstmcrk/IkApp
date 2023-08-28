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
        public string? Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public virtual AddressDTO? Address { get; set; }
        public virtual DepartmentDTO? Department { get; set; }
        public virtual TaskDTO? Task { get; set; }
        public string? ManagerId { get; set; }

    }
}
