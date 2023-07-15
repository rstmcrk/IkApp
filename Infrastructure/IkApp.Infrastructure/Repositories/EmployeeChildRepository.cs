using IkApp.Application.Repositories;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Infrastructure.Repositories
{
    public class EmployeeChildRepository : GenericRepository<EmployeeChild>, IEmployeeChildRepository
    {
        public EmployeeChildRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
