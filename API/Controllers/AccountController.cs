using AutoMapper;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public AccountController(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository= userAccountRepository;
            _mapper= mapper;
        }


        [HttpPost]
        public async Task<IActionResult> GetToken(UserAccountDto userAccountDto, [FromServices] IJwtRepository jwtRepository) 
        {
            var hash = SecurityHelper.GetSha256Hash(userAccountDto.Password);

            var user = await _userAccountRepository.TableNoTracking.AnyAsync(a => a.UserName == userAccountDto.UserName && a.Password == hash);
            if (user)
            {
                UserAccountDto _userAccountDto = new UserAccountDto
                {
                    UserName = userAccountDto.UserName,
                    Password = userAccountDto.Password,
                };
                var result = jwtRepository.CreateToken(userAccountDto);
                return Ok(result);
            }

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAccountDto userAccountDto) 
        {
            try
            {

                var hash = SecurityHelper.GetSha256Hash(userAccountDto.Password);
                var useraccount = _mapper.Map<UserAccount>(userAccountDto);
                useraccount.Password = hash;
                return Ok(await _userAccountRepository.AddAsync(useraccount));
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
