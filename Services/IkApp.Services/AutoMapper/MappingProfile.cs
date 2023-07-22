using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Domain.Entities;

namespace IkApp.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUserForRegisterModel, AppUser>();
            CreateMap<AppUser, AppUserDTO>();
        }
    }
}
