using IkApp.Application.Repositories;
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
    public class EmplooyeLoanedItemService : IEmplooyeLoanedItemService
    {
        public void Add(EmplooyeLoanedItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmplooyeLoanedItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EmplooyeLoanedItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EmplooyeLoanedItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EmplooyeLoanedItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EmplooyeLoanedItem> Where(Expression<Func<EmplooyeLoanedItem, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
