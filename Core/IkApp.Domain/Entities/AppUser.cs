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
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime StartDateOfWork { get; set; }
        public DateTime EndDateOfWork { get; set; }
        public Address Address { get; set; }
        public Department Department { get; set; }
        public Section Section { get; set; }
        public Task Task { get; set; }
        public ICollection<EmployeeChild> EmployeeChilds { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
        public ICollection<EmplooyeLoanedItem> EmplooyeLoanedItems { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public int? ManagerId { get; set; }
        public int? TeamLeaderId { get; set; }
        public int? BoddyId { get; set; }
    }
}
