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
    public class InsurancesController : ControllerBase
    {
        private readonly InsuranceServices _insuranceServices;

        public InsurancesController(IInsuranceRepository insuranceRepository, IMapper mapper)
        {
            _insuranceServices = new InsuranceServices(insuranceRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _insuranceServices.GetAll());
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
                var insurance = await _insuranceServices.GetById(Id);
                if (insurance != null)
                {
                    return Ok(insurance);
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
        public async Task<IActionResult> Create(InsuranceDto insuranceDto)
        {
            try
            {
                var result = await _insuranceServices.Create(insuranceDto);
                if (result.Status == ResponseStatus.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
              
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
                return Ok(await _insuranceServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(InsuranceDto insuranceDto)
        {
            try
            {
                return Ok(await _insuranceServices.Update(insuranceDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }

    }
}
