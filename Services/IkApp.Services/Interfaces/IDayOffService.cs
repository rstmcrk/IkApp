using IkApp.Application.DTOs;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Interfaces
{
    public interface IDayOffService : IService<DayOff>
    {
        Task<DayOffDTO> GetByUserIdAsync(string id);
    }
}
