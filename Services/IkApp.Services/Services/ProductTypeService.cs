using IkApp.Application.Services;
using IkApp.Application.UnitOfWork;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductType> GetAll()
        {
            return _unitOfWork.GetRepository<ProductType>().GetAll();
        }

        public Task<ProductType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductType> Where(Expression<Func<ProductType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
