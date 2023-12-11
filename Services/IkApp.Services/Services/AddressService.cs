using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.Services;
using IkApp.Application.UnitOfWork;
using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Added Address.
        /// </summary>
        /// <param name="entity">address entity</param>
        public void Add(Address entity)
        {
            var id = entity.AddressUserId;
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);

            // TODO : User cachelenecek.

            entity.AddressUser = user;
            _unitOfWork.GetRepository<Address>().Add(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            var address = await _unitOfWork.GetRepository<Address>().GetByIdAsync(id);
            return address;
        }

        public void Remove(Address entity)
        {
            _unitOfWork.GetRepository<Address>().Remove(entity);
            _unitOfWork.Commit();
        }

        public void Update(Address entity)
        {
            _unitOfWork.GetRepository<Address>().Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<Address> Where(Expression<Func<Address, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
