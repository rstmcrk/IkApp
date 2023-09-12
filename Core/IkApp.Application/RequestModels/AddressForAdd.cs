using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.RequestModels
{
    public class AddressForAdd
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
        public string PostCode { get; set; }
        public string AddressUserId { get; set; }
    }
}
