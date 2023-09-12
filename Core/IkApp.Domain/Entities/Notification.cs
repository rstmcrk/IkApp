using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class Notification
    {
        public int ID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationDetail { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
