using AutoMapper;
using Common.ApiResult;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    
      public class PermissionController : ControllerBase
    {
        private readonly PermissionServices _permissionServices;

        public PermissionController(IPermissionRepository ipermissionRepository, IMapper mapper)
        {
            _permissionServices = new PermissionServices(ipermissionRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _permissionServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var insurance = await _permissionServices.GetById(Id);
                if (insurance != null)
                {
                    return Ok(insurance);
                }
                else
                {
                    return Ok(new ServiceResult(ResponseStatus.NotFound, null));
                }

            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionDto permissionDto)
        {
            try
            {
                var result = await _permissionServices.Create(permissionDto);
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
                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));   
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _permissionServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PermissionDto permissionDto)
        {
            try
            {
                return Ok(await _permissionServices.Update(permissionDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));

            }
        }

    }
}
