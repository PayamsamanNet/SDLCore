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
    public class BranchManagersController : ControllerBase
    {
        private readonly BranchManagerServices _branchManagerServices;
        public BranchManagersController(IBranchManagerRepository branchManagerRepository, IMapper _mapper)
        {
            _branchManagerServices = new BranchManagerServices(branchManagerRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _branchManagerServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var branchManager = await _branchManagerServices.GetById(Id);
                if (branchManager != null)
                {
                    return Ok(branchManager);
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
        public async Task<IActionResult> Create(BranchManagerDto branchManagerDto)
        {
            try
            {
                return Ok(await _branchManagerServices.Create(branchManagerDto));
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
                return Ok(await _branchManagerServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BranchManagerDto branchManagerDto)
        {
            try
            {
                return Ok(await _branchManagerServices.Update(branchManagerDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));

            }
        }
    }
}
