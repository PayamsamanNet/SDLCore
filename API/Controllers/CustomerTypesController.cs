using AutoMapper;
using Common.ApiResult;
using Common.Pagination;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;

namespace Common.Temp
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomerTypesController : ControllerBase
    {
        private readonly CustomerTypeServices _customerTypeServices;
        public CustomerTypesController(ICustomerTypeRepository customerTypeRepository, IMapper _mapper)
        {
            _customerTypeServices = new CustomerTypeServices(customerTypeRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _customerTypeServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetByPagination(PagedResponse<CustomerTypeDto> pagedResponse)
        {
            try
            {
                return Ok(await _customerTypeServices.GetByPage(pagedResponse));
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }







        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var customerType = await _customerTypeServices.GetById(Id);
                if (customerType != null)
                {
                    return Ok(customerType);
                }
                else
                {
                    return BadRequest(new ServiceResult(ResponseStatus.NotFound,null));
                }

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerTypeDto customerTypeDto)
        {
            try
            {
                return Ok(await _customerTypeServices.Create(customerTypeDto));
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
                return Ok(await _customerTypeServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerTypeDto customerTypeDto)
        {
            try
            {
                return Ok(await _customerTypeServices.Update(customerTypeDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }

    }
}
