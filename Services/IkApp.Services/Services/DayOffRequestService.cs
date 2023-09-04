using IkApp.Application.UnitOfWork;
using IkApp.Domain.Entities;
using IkApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class DayOffRequestService : IDayOffRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DayOffRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(DayOffRequest entity)
        {
            _unitOfWork.GetRepository<DayOffRequest>().Add(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<DayOffRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DayOffRequest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(DayOffRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DayOffRequest entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DayOffRequest> Where(Expression<Func<DayOffRequest, bool>> expression)
        {
            return _unitOfWork.GetRepository<DayOffRequest>().Where(expression);
        }
    }
}
