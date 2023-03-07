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
    [Display(Name = "استان  ")]
    public class StatesController : ControllerBase
    {

        private readonly StateServices _stateServices;


        public StatesController(IStateRepository stateRepository, IMapper _mapper)
        {
            _stateServices = new StateServices(stateRepository, _mapper);
        }

        [HttpGet]
        [Display(Name = "لیست استان  ")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _stateServices.GetAll());
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet]
        [Display(Name = "جستجو استان  ")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var state = await _stateServices.GetById(Id);
                if (state != null)
                {
                    return Ok(state);
                }
                else
                {
                    return Ok(new ServiceResult(ResponseStatus.NotFound,null));
                }

            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError,"متن جهت تست می باشد "));
            }
        }

        [HttpPost]
        [Display(Name = "افزودن استان  ")]
        public async Task<IActionResult> Create(StateDto stateDto)
        {
            try
            {
                // stateDto.Id = Guid.NewGuid();
                return Ok(await _stateServices.Create(stateDto));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpDelete]
        [Display(Name = "حذف استان  ")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _stateServices.Delete(Id));
            }
            catch (Exception)
            {

                return Ok(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        [Display(Name = "ویرایش استان  ")]
        public async Task<IActionResult> Update(StateDto stateDto)
        {
            try
            {
                return Ok(await _stateServices.Update(stateDto));
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

    }
}
