using IkApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class TaskService : ITaskService
    {
        public void Add(Domain.Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Task> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.Task> Where(Expression<Func<Domain.Entities.Task, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
