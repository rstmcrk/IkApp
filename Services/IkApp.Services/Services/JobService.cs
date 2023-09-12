using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.UnitOfWork;
using IkApp.Domain.Entities;
using IkApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Add(Job entity)
        {
            _unitOfWork.GetRepository<Job>().Add(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Job> GetAll()
        {
            return _unitOfWork.GetRepository<Job>().GetAll().Include(job => job.JobUser).Include(job => job.JobUser.Department)
                .Where(job => job.Status != "Tamamlandı");
        }

        public Task<Job> GetByIdAsync(int id)
        {
            return _unitOfWork.GetRepository<Job>().GetByIdAsync(id);
        }

        public void Remove(Job entity)
        {
            _unitOfWork.GetRepository<Job>().Remove(entity);
            _unitOfWork.Commit();
        }

        public void Update(Job entity)
        {
            _unitOfWork.GetRepository<Job>().Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Job> Where(Expression<Func<Job, bool>> expression)
        {
            return _unitOfWork.GetRepository<Job>().Where(expression);
        }
    }
}
