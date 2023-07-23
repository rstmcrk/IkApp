using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.Services;
using IkApp.Cache;
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
        private readonly ICacheManager _cacheManager;

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, ICacheManager cacheManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cacheManager = cacheManager;
        }

        public void Add(AppUser entity)
        {
            // adding user

            _cacheManager.Remove("users");
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
            var users = await _cacheManager.GetAsync("users", async() =>
            {
                return await _userManager.Users.ToListAsync();
            }, new TimeSpan(0, 10, 0));

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
