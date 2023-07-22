using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
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
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AppUserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUserDTO>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var userDTOs = _mapper.Map<List<AppUserDTO>>(users);

            return userDTOs;
        }

        public void Remove(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> Where(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
