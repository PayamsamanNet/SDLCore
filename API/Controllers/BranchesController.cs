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
    public class BranchesController : ControllerBase
    {
        private readonly BranchServices _branchServices;
        public BranchesController(IBranchRepository branchRepository, IMapper _mapper)
        {
            _branchServices = new BranchServices(branchRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _branchServices.GetAll());
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
                var branch = await _branchServices.GetById(Id);
                if (branch != null)
                {
                    return Ok(branch);
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
        public async Task<IActionResult> Create(BranchDto branchDto, [FromServices]IAddressRepository addressRepository )
        {
            try
            {
                return Ok(await _branchServices.Create(branchDto, addressRepository));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id, [FromServices] IAddressRepository addressRepository)
        {
            try
            {
                return Ok(await _branchServices.Delete(Id, addressRepository));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BranchDto branchDto, [FromServices] IAddressRepository addressRepository)
        {
            try
            {
                var update = await _branchServices.Update(branchDto, addressRepository);
                if (update.Status == ResponseStatus.Success)
                {
                    return Ok(update);
                }
                return BadRequest(update);
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
