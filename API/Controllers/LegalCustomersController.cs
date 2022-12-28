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
    public class LegalCustomersController : ControllerBase
    {
        private readonly LegalCustomerServices _legalCustomerServices;

        public LegalCustomersController(ILegalCustomerRepository legalCustomerRepository, IMapper mapper)
        {
            _legalCustomerServices = new LegalCustomerServices(legalCustomerRepository, mapper);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _legalCustomerServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var legalCustomer = await _legalCustomerServices.GetById(Id);
                if (legalCustomer != null)
                {
                    return Ok(legalCustomer);
                }
                else
                {
                    return Ok(new ServiceResult(ResponseStatus.NotFound));
                }

            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LegalCustomerDto legalCustomerDto)
        {
            try
            {
                return Ok(await _legalCustomerServices.Create(legalCustomerDto));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _legalCustomerServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(LegalCustomerDto legalCustomerDto)
        {
            try
            {
                return Ok(await _legalCustomerServices.Update(legalCustomerDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));

            }
        }
    }
}
