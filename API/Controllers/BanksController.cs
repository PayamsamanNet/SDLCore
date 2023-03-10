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
    public class BanksController : ControllerBase
    {
        private readonly BankServices _bankServices;
        public BanksController(IBankRepository bankRepository, IMapper _mapper)
        {
            _bankServices = new BankServices(bankRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _bankServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetByPagination(PagedResponse<BankDto> pagedResponse)
        {
            try
            {
                return Ok(await _bankServices.GetByPgination(pagedResponse));
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
                var bank = await _bankServices.GetById(Id);
                if (bank != null)
                {
                    return Ok(bank);
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
        public async Task<IActionResult> Create(BankDto bankDto)
        {
            try
            {
                return Ok(await _bankServices.Create(bankDto));
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
                return Ok(await _bankServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BankDto bank)
        {
            try
            {
                return Ok(await _bankServices.Update(bank));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
