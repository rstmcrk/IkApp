using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionUserId { get; set; }
        public AppUser SectionUser { get; set; }
    }
}
