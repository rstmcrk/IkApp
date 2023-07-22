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
    public class EmployeeDetailService : IEmployeeDetailService
    {
        public void Add(EmployeeDetail entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EmployeeDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeDetail entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmployeeDetail> Where(Expression<Func<EmployeeDetail, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
