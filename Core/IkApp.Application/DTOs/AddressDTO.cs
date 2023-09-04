using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.DTOs
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
        public string PostCode { get; set; }
    }
}
