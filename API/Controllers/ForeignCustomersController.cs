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
    public class ForeignCustomersController : ControllerBase
    {
        private readonly ForeginCustomerServices _foreginCustomerServices;
        public ForeignCustomersController(IForeignCustomerRepository foreignCustomerRepository, IMapper _mapper)
        {
            _foreginCustomerServices = new ForeginCustomerServices(foreignCustomerRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _foreginCustomerServices.GetAll());
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
                var foreignCustomer = await _foreginCustomerServices.GetById(Id);
                if (foreignCustomer != null)
                {
                    return Ok(foreignCustomer);
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
        public async Task<IActionResult> Create(ForeignCustomerDto foreignCustomerDto)
        {
            try
            {
                return Ok(await _foreginCustomerServices.Create(foreignCustomerDto));
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
                return Ok(await _foreginCustomerServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ForeignCustomerDto foreignCustomerDto)
        {
            try
            {
                return Ok(await _foreginCustomerServices.Update(foreignCustomerDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
