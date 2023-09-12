using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class DayOffRequest
    {
        public int ID { get; set; }
        public string PermissionType { get; set; }
        public string PermissionDetail { get; set; }
        public float DayOffNumber { get; set; }
        public DateTime PermissionStart { get; set; }
        public DateTime PermissionEnd { get; set; }
        public bool Approval { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
