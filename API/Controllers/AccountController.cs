﻿using AutoMapper;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Authentication;

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


        [HttpGet]
        public async Task<IActionResult> GetToken(string Username, string Password, [FromServices] IJwtRepository jwtRepository) 
        {
            var hash = SecurityHelper.GetSha256Hash(Password);

            var user =await _userAccountRepository.TableNoTracking.AnyAsync(a => a.UserName == Username && a.Password == hash);
            if (user)
            {
                UserAccountDto userAccountDto = new UserAccountDto
                {
                    UserName = Username,
                    Password = Password,
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
