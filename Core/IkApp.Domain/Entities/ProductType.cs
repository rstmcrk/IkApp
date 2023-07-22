using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Domain.Entities
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public int? EmplooyeLoanedItemId { get; set; }
        public EmplooyeLoanedItem? EmplooyeLoanedItem { get; set; }
    }
}
