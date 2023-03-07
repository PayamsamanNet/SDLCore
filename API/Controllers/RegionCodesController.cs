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
    [Display(Name = "منطقه ")]
    public class RegionCodesController : ControllerBase
    {
        private readonly RegionCodeServices _regionCodeServices;
        public RegionCodesController(IRegionCodeRepository regionCodeRepository, IMapper mapper)
        {
            _regionCodeServices = new RegionCodeServices(regionCodeRepository, mapper);
        }
        [HttpGet]
        [Display(Name = "لیست منطقه  ")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _regionCodeServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet]
        [Display(Name = "جستجو منطقه  ")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var regionCode = await _regionCodeServices.GetById(Id);
                if (regionCode != null)
                {
                    return Ok(regionCode);
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
        [Display(Name = "افزودن منطقه  ")]
        public async Task<IActionResult> Create(RegionCodeDto regionCodeDto)
        {
            try
            {
                return Ok(await _regionCodeServices.Create(regionCodeDto));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpDelete]
        [Display(Name = "حذف منطقه  ")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                return Ok(await _regionCodeServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        [Display(Name = "ویرایش منطقه  ")]
        public async Task<IActionResult> Update(RegionCodeDto regionCodeDto)
        {
            try
            {
                return Ok(await _regionCodeServices.Update(regionCodeDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
