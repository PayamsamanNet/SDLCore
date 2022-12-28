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
    public class CitiesController : ControllerBase
    {
        private readonly CityServices _cityServices;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityServices = new CityServices(cityRepository, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _cityServices.GetAll());
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
                var city = await _cityServices.GetById(Id);
                if (city != null)
                {
                    return Ok(city);
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
        public async Task<IActionResult> Create(CityDto cityDto)
        {
            try
            {
                return Ok(await _cityServices.Create(cityDto));
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
                return Ok(await _cityServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityDto cityDto)
        {
            try
            {
                return Ok(await _cityServices.Update(cityDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError));

            }
        }

    }
}
