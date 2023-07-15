using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class EmplooyeLoanedItem
    {
        public int EmplooyeLoanedItemId { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
