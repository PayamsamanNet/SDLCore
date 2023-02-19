using AutoMapper;
using Common.ApiResult;
using Data.Dto;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;

namespace Common.Temp
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class IbansController : ControllerBase
    {
        private readonly IbanServices _ibanServices;
        public IbansController(IbanRepository ibanRepository, IMapper _mapper)
        {
            _ibanServices = new IbanServices(ibanRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _ibanServices.GetAll());
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
                var iban = await _ibanServices.GetById(Id);
                if (iban != null)
                {
                    return Ok(iban);
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
        public async Task<IActionResult> Create(IbanDto ibanDto)
        {
            try
            {
                return Ok(await _ibanServices.Create(ibanDto));
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
                return Ok(await _ibanServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(IbanDto ibanDto)
        {
            try
            {
                return Ok(await _ibanServices.Update(ibanDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
