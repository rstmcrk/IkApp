using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.RequestModels
{
    public class PermissionRejectModel
    {
        public int ID { get; set; }
        public bool Approval { get; set; }
        public bool status { get; set; }
    }
}
