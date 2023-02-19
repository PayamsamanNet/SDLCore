using AutoMapper;
using Common.ApiResult;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _Mapper;
        public RoleController(RoleManager<Role> roleManager, IMapper Mapper)
        {
            _Mapper= Mapper;
            _roleManager= roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Result=await _roleManager.Roles.ToListAsync();
                return Ok(_Mapper.Map<List<Role>,List<RoleDto>>(Result));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto role)
        {
            try
            {
                Role Role = new Role
                {
                    Description = role.Description,
                    Name = role.Name,
                    NormalizedName = role.NormalizedName,
                };
                //var role = _Mapper.Map<RoleDto, Role>(roleDto);
                //role.Id ="";
                var Result= await _roleManager.CreateAsync(Role);
                if (Result.Succeeded)
                {
                    return Ok(new ServiceResult(ResponseStatus.Success,null));
                }
                else
                {
                    string Message = "";
                    foreach (var item in Result.Errors)
                    {
                        Message= Message +" " + item.Description.ToString();
                    }
                    return BadRequest(new ResponceApi
                    {
                        Message = Message,
                    });
                }
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto role)
        {
            try
            {

                var Role = _Mapper.Map<RoleDto, Role>(role);
                //var Result = await _roleManager.UpdateAsync(Role);
                var Result = await _roleManager.UpdateAsync(Role);
                if (Result.Succeeded)
                {
                    return Ok(new ServiceResult(ResponseStatus.Success,null));
                }
                else
                {
                    string Message = "";
                    foreach (var item in Result.Errors)
                    {
                        Message = Message + " " + item.Description.ToString();
                    }
                    return BadRequest(new ResponceApi
                    {
                        Message = Message,
                    });
                }
            }
            catch (Exception)
            {

                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var Role=await _roleManager.FindByIdAsync(Id);
                return Ok(_Mapper.Map<Role,RoleDto>(Role));
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError,null));
            }
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
