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
    public class AddressService : IAddressService
    {
        public void Add(Address entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Address entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> Where(Expression<Func<Address, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
