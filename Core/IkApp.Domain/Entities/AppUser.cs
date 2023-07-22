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
        public DateTime? StartDateOfWork { get; set; }
        public DateTime? EndDateOfWork { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Task? Task { get; set; }
        public virtual ICollection<EmployeeChild>? EmployeeChilds { get; set; }
        public virtual EmployeeDetail? EmployeeDetail { get; set; }
        public virtual ICollection<EmplooyeLoanedItem>? EmplooyeLoanedItems { get; set; }
        public virtual ICollection<Announcement>? Announcements { get; set; }
        public int? ManagerId { get; set; }
        public int? TeamLeaderId { get; set; }
        public int? BoddyId { get; set; }
    }
}
