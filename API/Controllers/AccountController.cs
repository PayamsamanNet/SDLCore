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

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> signInManager, IUserAccountRepository userAccountRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userAccountRepository= userAccountRepository;
            _mapper= mapper;
            _userManager = userManager;
            _signInManager= signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> GetToken(UserAccountDto userAccountDto, [FromServices] IJwtRepository jwtRepository) 
        {
            var hash = SecurityHelper.GetSha256Hash(userAccountDto.Password);

            var user = await _userAccountRepository.TableNoTracking.AnyAsync(a => a.UserName == userAccountDto.UserName && a.Password == hash);
            if (user)
            {
                //UserAccountDto _userAccountDto = new UserAccountDto
                //{
                //    UserName = userAccountDto.UserName,
                //    Password = userAccountDto.Password,
                //};
                //var result = jwtRepository.CreateToken(userAccountDto);
                //return Ok(result);
            }

            return null;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(UserAccountDto userAccountDto) 
        //{
        //    try
        //    {

        //        var hash = SecurityHelper.GetSha256Hash(userAccountDto.Password);
        //        var useraccount = _mapper.Map<UserAccount>(userAccountDto);
        //        useraccount.Password = hash;
        //        return Ok(await _userAccountRepository.AddAsync(useraccount));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            try
            {
                var User=_mapper.Map<User>(userDto);
                var Result=await _userManager.CreateAsync(User);
                if (Result.Succeeded)
                {
                   return Ok(new ResultIdentity { Message= EnumExtensions.GetEnumDescription(ResponseStatus.Success),Status= ResponseStatus.Success });
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
        public async Task<IActionResult> Login(LoginDto loginDto, [FromServices] IJwtRepository jwtRepository)
        {
            var _User = await _userManager.FindByNameAsync(loginDto.UserName);
            if (_User == null)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.NotFound), Status = ResponseStatus.NotFound });
            }
            else
            {
                var checkPass = await _signInManager.CheckPasswordSignInAsync(_User, loginDto.Password, false);
                if (checkPass.Succeeded)
                {
                    var userdto = _mapper.Map<UserDto>(_User);
                    return Ok(jwtRepository.CreateToken(userdto));
                }


               

            }

            return Ok();
        }
    }
}
