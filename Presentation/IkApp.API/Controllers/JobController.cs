using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
using IkApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public JobController(IJobService jobService, IMapper mapper, IAppUserService appUserService)
        {
            _jobService = jobService;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult GetJobs()
        {
           var jobs = _jobService.GetAll();
            var jobDtos = _mapper.Map<List<JobDTO>>(jobs);
            return Ok(jobDtos);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete]
        public async Task<IActionResult> DeletJob(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            _jobService.Remove(job);
            return Ok(200);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getJob")]
        public IActionResult GetJob()
        {
            var userId = HttpContext.Request.Query["userId"].ToString();
            var jobs = _jobService.Where(x => x.JobUserId == userId && x.Status != "Tamamlandı");
            var jobsDto = _mapper.Map<List<JobDTO>>(jobs);
            return Ok(jobsDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addJob")]
        public async Task<IActionResult> AddJob(JobForAdd jobdata)
        {
            var user = await _appUserService.GetUserForUserName(jobdata.User.UserName);
            jobdata.User = user;
            var jobdataDto = _mapper.Map<Job>(jobdata);
            jobdataDto.JobUserId = user.Id;
            _jobService.Add(jobdataDto);
            return Ok(201);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateJob")]
        public async Task<IActionResult> updateJob(JobDTO jobdata)
        {
            var user = await _appUserService.GetUserForUserName(jobdata.JobUser.UserName);
            jobdata.JobUser = user;
            var jobdataDto = _mapper.Map<Job>(jobdata);
            jobdataDto.JobUser = null;
            jobdataDto.JobUserId = user.Id;
            _jobService.Update(jobdataDto);
            return Ok(200);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("updateStatus")]
        public async Task<IActionResult> UpdateJobStatus(JobDTO jobdata)
        {
            var job = _jobService.Where(x => x.Id == jobdata.Id).FirstOrDefault();
            job.Status = jobdata.Status;
            _jobService.Update(job);
            return Ok(200);
        }
    }
}
