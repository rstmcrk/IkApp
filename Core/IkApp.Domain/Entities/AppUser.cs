using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? StartDateOfWork { get; set; }
        public DateTime? EndDateOfWork { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Task? Task { get; set; }
        public virtual ICollection<Job>? Jobs { get; set; }
        public virtual DayOff? DayOff { get; set; }
        public virtual ICollection<DayOffRequest>? DayOffRequests { get; set; }
        public string? ManagerId { get; set; }
    }
}
