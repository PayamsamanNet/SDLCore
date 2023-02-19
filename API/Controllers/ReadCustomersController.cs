using AutoMapper;
using Common.ApiResult;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;

namespace Common.Temp
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ReadCustomersController : ControllerBase
    {
        private readonly RealCustomerServices _realCustomerServices;

        public ReadCustomersController(IRealCustomerRepository realCustomerRepository, IMapper mapper)
        {
            _realCustomerServices = new RealCustomerServices(realCustomerRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _realCustomerServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var realCustomer = await _realCustomerServices.GetById(Id);
                if (realCustomer != null)
                {
                    return Ok(realCustomer);
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
        public async Task<IActionResult> Create(RealCustomerDto realCustomerDto)
            {
        try
           {
              return Ok(await _realCustomerServices.Create(realCustomerDto));
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
                return Ok(await _realCustomerServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RealCustomerDto realCustomerDto)
        {
            try
            {
                return Ok(await _realCustomerServices.Update(realCustomerDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
