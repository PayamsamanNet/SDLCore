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
    public class RepositoriesController : ControllerBase
    {
        private readonly RepositoryServices _repositoryServices;

        public RepositoriesController(IRepositoryRepository repositoryRepository, IMapper mapper)
        {
            _repositoryServices = new RepositoryServices(repositoryRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repositoryServices.GetAll());
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
                var repository = await _repositoryServices.GetById(Id);
                if (repository != null)
                {
                    return Ok(repository);
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
        public async Task<IActionResult> Create(RepositoryDto repositoryDto)
        {
            try
            {
                return Ok(await _repositoryServices.Create(repositoryDto));
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
                return Ok(await _repositoryServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RepositoryDto repositoryDto)
        {
            try
            {
                return Ok(await _repositoryServices.Update(repositoryDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));

            }
        }
    }
}
