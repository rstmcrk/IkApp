using IkApp.Application.Repositories;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Infrastructure.Repositories
{
    public class EmplooyeLoanedItemRepository : GenericRepository<EmplooyeLoanedItem>, IEmplooyeLoanedItemRepository
    {
        public EmplooyeLoanedItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
