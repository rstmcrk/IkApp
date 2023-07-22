using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IkApp.Caching.CacheService
{
    public class AppUserServiceWithCaching : IAppUserService
    {
        private readonly string appUser = "appUserCaches";
        private readonly IAppUserService _appUserService;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheDb;

        public AppUserServiceWithCaching(RedisService redisService, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _redisService = redisService;
            _cacheDb = _redisService.GetDb(0);
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
            if (!await _cacheDb.KeyExistsAsync(appUser))
            {
                return await LoadToCacheFromDbAsync();
            }

            var users = new List<AppUserDTO>();

            var cacheUser = await _cacheDb.HashGetAllAsync(appUser);
            foreach (var item in cacheUser.ToList())
            {
                var user = JsonSerializer.Deserialize<AppUserDTO>(item.Value);

                users.Add(user);
            }
            return users;
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

        private async Task<List<AppUserDTO>> LoadToCacheFromDbAsync()
        {
            var userDTOs = await _appUserService.GetUsers();

            userDTOs.ForEach(u =>
            {
                _cacheDb.StringSet("hfdg","hgf",new TimeSpan(0,10,0));
            });
                
            return userDTOs;
        }
    }
}
