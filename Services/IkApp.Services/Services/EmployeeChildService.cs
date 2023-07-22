using IkApp.Application.Services;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class EmployeeChildService : IEmployeeChildService
    {
        public void Add(EmployeeChild entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeChild> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeChild> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EmployeeChild entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeChild entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeChild> Where(Expression<Func<EmployeeChild, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
