using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public int DepartmentId { get; set; }
        public int RelatedPersonId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AnnouncementUserId { get; set; }
        public AppUser AnnouncementUser { get; set; }
    }
}
