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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Section entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Section> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Section entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Section entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Section> Where(Expression<Func<Section, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
