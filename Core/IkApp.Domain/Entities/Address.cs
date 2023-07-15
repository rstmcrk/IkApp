using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
        public string PostCode { get; set; }
        public string AddressUserId { get; set; }
        public AppUser AddressUser { get; set; }
    }
}
