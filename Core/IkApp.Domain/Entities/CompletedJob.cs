using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class CompletedJob
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobDetail { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Precedence { get; set; }
        public string Status { get; set; }
        public string JobUserId { get; set; }
        public AppUser JobUser { get; set; }
    }
}
