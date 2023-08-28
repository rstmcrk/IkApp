using IkApp.Application.DTOs;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.RequestModels
{
    public class JobForAdd
    {
        public string JobName { get; set; }
        public string JobDetail { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Precedence { get; set; }
        public string Status { get; set; }
        public AppUserDTO? User { get; set; }
    }
}
