using AutoMapper;
using IkApp.Application.DTOs;
using IkApp.Application.RequestModels;
using IkApp.Application.Services;
using IkApp.Domain.Entities;
using IkApp.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IkApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        public AddressController(IMapper mapper, IAddressService addressService, IAppUserService appUserService)
        {
            _mapper = mapper;
            _addressService = addressService;
            _appUserService = appUserService;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("addAddress")]
        public IActionResult AddAddress(AddressForAdd addressForAdd)
        {
            if (addressForAdd == null)
            {
                return BadRequest();
            }
            else
            {
                var address = _mapper.Map<Address>(addressForAdd);
                _addressService.Add(address);    
            }
            return StatusCode(201);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete]
        public async Task<IActionResult> deleteAddress(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            if (address != null)
            {
                _addressService.Remove(address);
            }
            return Ok();
        }
    }
}
