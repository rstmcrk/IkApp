
using IkApp.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IkApp.Infrastructure;
using IkApp.Application.Repositories;
using IkApp.Application.UnitOfWork;
using IkApp.Infrastructure.UnitOfWork;

namespace IkApp.Services
{
    public static class DIModule
    {
        public static IServiceCollection AddIdentityOptions(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                         options.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
