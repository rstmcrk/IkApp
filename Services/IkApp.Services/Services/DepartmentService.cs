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
    public class DepartmentService : IDepartmentService
    {
        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> Where(Expression<Func<Department, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
