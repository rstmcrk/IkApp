using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Domain.Entities;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUserForRegisterModel, AppUser>();
            CreateMap<DepartmentForAdd, Department>();
            CreateMap<TaskForAdd, Task>();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AddressForAdd, Address>();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Task, TaskDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<Job, JobForAdd>().ReverseMap();
            CreateMap<DayOff, DayOffDTO>().ReverseMap();
            CreateMap<DayOffRequest, DayOffRequestDTO>().ReverseMap();
            CreateMap<DayOffRequest, RequestForDayOff>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
