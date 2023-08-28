
using IkApp.Application.DTOs;
using IkApp.Domain.Entities;

namespace IkApp.Application.RequestModels
{
    public record AppUserForRegisterModel
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public DateTime? StartDateOfWork { get; set; }
        public virtual AddressForAdd? Address { get; set; }
        public virtual DepartmentForAdd? Department { get; set; }
        public virtual TaskForAdd? Task { get; set; }
        public virtual DayOffDTO? DayOff { get; set; }
        public string? Password { get; init; }
        public string? ManagerId { get; set; }
    }
}
