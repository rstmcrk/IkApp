using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.DTOs
{
    public class DayOffDTO
    {
        public float? RemainingDayOff { get; set; }
        public DateTime? DayOffAssignmentDate { get; set; }
        public float? DayOffAssign { get; set; }
    }
}
