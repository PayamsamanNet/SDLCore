using AutoMapper;
using Common.ApiResult;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.EntityServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Common.Temp
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Display(Name = " مخازن  ")]
    public class RepositoriesController : ControllerBase
    {
        private readonly RepositoryServices _repositoryServices;

        public RepositoriesController(IRepositoryRepository repositoryRepository, IMapper mapper)
        {
            _repositoryServices = new RepositoryServices(repositoryRepository, mapper);
        }

        [HttpGet]
        [Display(Name = "لیست مخازن ")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repositoryServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet]
        [Display(Name = "جستجو مخازن ")]
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
                    return Ok(new ServiceResult(ResponseStatus.NotFound,null));
                }

            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPost]
        [Display(Name = "افزودن مخزن  ")]
        public async Task<IActionResult> Create(RepositoryDto repositoryDto)
        {
            try
            {
                return Ok(await _repositoryServices.Create(repositoryDto));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpDelete]
        [Display(Name = "حذف مخزن  ")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _repositoryServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        [Display(Name = "ویرایش مخزن  ")]
        public async Task<IActionResult> Update(RepositoryDto repositoryDto)
        {
            try
            {
                return Ok(await _repositoryServices.Update(repositoryDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
