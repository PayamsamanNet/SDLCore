using AutoMapper;
using Common.ApiResult;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Common.Temp
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]

    public class AddressesController : ControllerBase
    {
        private readonly AddressServices _addressServices;
        public AddressesController(IAddressRepository addressRepository, IMapper _mapper)
        {
            _addressServices = new AddressServices(addressRepository, _mapper);
        }

        [HttpGet]
        [Display(Name = "ورود به سامانه ")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _addressServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet("{id})")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var address = await _addressServices.GetById(Id);
                if (address != null)
                {
                    return Ok(address);
                }
                else
                {
                    return Ok(new ServiceResult(ResponseStatus.NotFound,null));
                }

            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressDto addressDto)
        {
            try
            {
                return Ok(await _addressServices.Create(addressDto));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _addressServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressDto addressDto)
        {
            try
            {
                return Ok(await _addressServices.Update(addressDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }


    }
}
