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
    public class RepositoryColumnsController : ControllerBase
    {
        private readonly RepositoryColumnServices _repositoryColumnServices;

        public RepositoryColumnsController(IRepositoryColumnRepository repositoryColumnRepository, IMapper mapper)
        {
            _repositoryColumnServices = new RepositoryColumnServices(repositoryColumnRepository, mapper);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repositoryColumnServices.GetAll());
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
                var repositoryColumn = await _repositoryColumnServices.GetById(Id);
                if (repositoryColumn != null)
                {
                    return Ok(repositoryColumn);
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
        public async Task<IActionResult> Create(RepositoryColumnDto repositoryColumnDto)
        {
            try
            {
                return Ok(await _repositoryColumnServices.Create(repositoryColumnDto));
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
                return Ok(await _repositoryColumnServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RepositoryColumnDto repositoryColumnDto)
        {
            try
            {
                return Ok(await _repositoryColumnServices.Update(repositoryColumnDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));

            }
        }
    }
}
