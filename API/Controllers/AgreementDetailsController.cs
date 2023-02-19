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
    public class AgreementDetailsController : ControllerBase
    {

        private readonly AgreementDetailServices _agreementDetailServices;
        public AgreementDetailsController(IAgreementDetailRepository agreementDetailRepository, IMapper _mapper)
        {
            _agreementDetailServices = new AgreementDetailServices(agreementDetailRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _agreementDetailServices.GetAll());
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
                var agreementDetail = await _agreementDetailServices.GetById(Id);
                if (agreementDetail != null)
                {
                    return Ok(agreementDetail);
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
        public async Task<IActionResult> Create(AgreementDetailDto agreementDetailDto)
        {
            try
            {
                return Ok(await _agreementDetailServices.Create(agreementDetailDto));
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
                return Ok(await _agreementDetailServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(AgreementDetailDto agreementDetailDto)
        {
            try
            {
                return Ok(await _agreementDetailServices.Update(agreementDetailDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
