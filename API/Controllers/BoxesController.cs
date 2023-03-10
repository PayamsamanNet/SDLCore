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
    public class BoxesController : ControllerBase
    {
        private readonly BoxServices _boxServices;
        public BoxesController(IBoxRepository boxRepository, IMapper _mapper)
        {
            _boxServices = new BoxServices(boxRepository, _mapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _boxServices.GetAll());
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var box = await _boxServices.GetById(Id);
                if (box != null)
                {
                    return Ok(box);
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
        public async Task<IActionResult> Create(BoxDto boxDto)
        {
            try
            {
                return Ok(await _boxServices.Create(boxDto));
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
                return Ok(await _boxServices.Delete(Id));

            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BoxDto boxDto)
        {
            try
            {
                return Ok(await _boxServices.Update(boxDto));

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));

            }
        }
    }
}
