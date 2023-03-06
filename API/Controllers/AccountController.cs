using AutoMapper;
using Common.ApiResult;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Service.Authentication;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager,  IMapper mapper, UserManager<User> userManager)
        {
           
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            try
            {
                var _User = _mapper.Map<UserDto,User>(userDto);
                var _Id = Guid.NewGuid();
                _User.Id = _Id.ToString();
                var Result = await _userManager.CreateAsync(_User, userDto.PasswordHash);
                if (Result.Succeeded)
                {
                    return Ok(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.Success), Status = ResponseStatus.Success });
                }
                else
                {
                    string Error = "";
                    foreach (var item in Result.Errors)
                    {
                        Error = Error + "," + item.Description;
                    }
                    return BadRequest(new ResultIdentity { Message = Error, Status = ResponseStatus.BadRequest });
                }
            }
            catch (Exception)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });
            }
        }
        [HttpPost]
        [DisplayName("ورود کاربر ")]
        public async Task<IActionResult> Login(LoginDto loginDto, [FromServices] IJwtRepository jwtRepository)
        {
            try
            {
                var asm = typeof(AccountController).Assembly;
                var rsr = OthersExtensions.

                var _User = await _userManager.FindByNameAsync(loginDto.UserName);
                if (_User == null)
                {
                    return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.NotFoundUser), Status = ResponseStatus.NotFoundUser });
                }
                else
                {
                    var checkPass = await _signInManager.CheckPasswordSignInAsync(_User, loginDto.Password, true);

                    if (checkPass.Succeeded)
                    {
                        var userdto = _mapper.Map<UserDto>(_User);
                        var res = jwtRepository.CreateToken(userdto);
                        return Ok(new ResponseAccount<UserDto>
                        {
                            data = userdto,
                            Roles = res.Roles,
                            Token = res.Token,
                            status = res.status
                        });
                    }
                    else
                    {
                        return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.NotFound), Status = ResponseStatus.NotFound });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });

            }
        }
    }
}
