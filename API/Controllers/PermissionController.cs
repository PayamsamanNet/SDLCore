using AutoMapper;
using Common.ApiResult;
using Common.Utilities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.EntityServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Display(Name = " دسترسی ها ")]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionServices _permissionServices;

        public PermissionController(IPermissionRepository ipermissionRepository, IMapper mapper)
        {
            _permissionServices = new PermissionServices(ipermissionRepository, mapper);
        }

        [HttpGet]
        [Display(Name = " لیست ")]
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
        [Display(Name = " جستجو ")]
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
        [Display(Name = " افزودن ")]
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
        [Display(Name = " حذف ")]
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
        [Display(Name = " ویرایش ")]
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

        public async Task<IActionResult> GetAllAcessProject()
        {
            try
            {
                var asm = typeof(AccountController).Assembly;
                var Result = OthersExtensions.GetAccessProject<ControllerBase>(asm);
                if (Result == null)
                {
                    return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));
                }
                else
                {
                    return Ok(Result);
                }
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleByPerMission(string RoleId, [FromServices] IRolePermissionRepository rolePermission)
        {
            try
            {
                var List = await _permissionServices.GetAll();
                var RolePermission =await rolePermission.Table.Where(s => s.RoleId == RoleId).ToListAsync();
                List<PermissionDto> permissions= new List<PermissionDto>();
                foreach (var item in List)
                {
                    var Exsit = RolePermission.Any(d => d.PermissionId == item.Id && d.RoleId == RoleId);
                    if (Exsit)
                    {
                        permissions.Add(new PermissionDto
                        {
                            Title = item.Title,
                            Code = item.Code,
                            Id = item.Id,
                            IsChecked = true,
                            SubCode = item.SubCode,
                            IsMenu = item.IsMenu,
                            Url = item.Url,
                        });
                    }
                    else
                    {
                        permissions.Add(new PermissionDto
                        {
                            Title = item.Title,
                            Code = item.Code,
                            Id = item.Id,
                            IsChecked = false,
                            SubCode = item.SubCode,
                            IsMenu = item.IsMenu,
                            Url = item.Url,
                        });
                    }

                }

                return Ok(permissions);

            }
            catch (Exception)
            {
                return BadRequest(new ServiceResult(ResponseStatus.ServerError, null));
            }
        }



    }
}
