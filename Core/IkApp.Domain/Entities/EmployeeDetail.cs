using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class EmployeeDetail
    {
        public int EmployeeDetailId { get; set; }
        public string DetailJson { get; set; }
        public string EmployeeId { get; set; }
        public AppUser EmployeeDetailUser { get; set; }
    }
}
