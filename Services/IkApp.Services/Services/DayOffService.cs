using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.UnitOfWork;
using IkApp.Domain.Entities;
using IkApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class DayOffService : IDayOffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public DayOffService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public void Add(DayOff entity)
        {
            //entity.RemainingDayOff = 0;
            //entity.DayOffAssignmentDate = DateTime.Now.AddYears(1);
            //entity.DayOffAssign = 14;
            _unitOfWork.GetRepository<DayOff>().Add(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<DayOff> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DayOff> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<DayOff>().GetByIdAsync(id);
        }

        public async Task<DayOffDTO> GetByUserIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var dayOff = _userManager.Users
                .Include(u => u.DayOff)
                .FirstOrDefault(u => u.Id == user.Id);
            var dayOffDto = _mapper.Map<DayOffDTO>(dayOff.DayOff);
            return dayOffDto;
        }

        public void Remove(DayOff entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DayOff entity)
        {
            _unitOfWork.GetRepository<DayOff>().Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<DayOff> Where(Expression<Func<DayOff, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
