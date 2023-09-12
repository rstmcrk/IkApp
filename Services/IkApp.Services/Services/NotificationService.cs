using AutoMapper;
using IkApp.Application.DTOs;
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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Add(Notification entity)
        {
            _unitOfWork.GetRepository<Notification>().Add(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<Notification>().GetByIdAsync(id);
        }

        public void Remove(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification entity)
        {
            _unitOfWork.GetRepository<Notification>().Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Notification> Where(Expression<Func<Notification, bool>> expression)
        {
            return _unitOfWork.GetRepository<Notification>().Where(expression);
        }
    }
}
