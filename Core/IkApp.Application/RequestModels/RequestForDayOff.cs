using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.RequestModels
{
    public class RequestForDayOff
    {
        public string? PermissionType { get; set; }
        public string? PermissionDetail { get; set; }
        public float? DayOffNumber { get; set; }
        public DateTime? PermissionStart { get; set; }
        public DateTime? PermissionEnd { get; set; }
        public bool? Approval { get; set; }
        public bool? Status { get; set; }
        public string? UserId { get; set; }
    }
}
