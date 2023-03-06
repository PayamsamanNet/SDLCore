using AutoMapper;
using Common.ApiResult;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersController(SignInManager<User> signInManager, IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        [HttpPost]
        public  async Task<IActionResult> Create(UserDto userDto)
        {
            try
            {
                var _User = _mapper.Map<UserDto, User>(userDto);
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
        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            try
            {

                var _User = _mapper.Map<UserDto, User>(userDto);
                _User.SecurityStamp = Guid.NewGuid().ToString();
                var exists = await _userRepository.Entities.FirstOrDefaultAsync(d=>d.Id == userDto.Id);

                if (exists != null)
                {
                    exists.Name = userDto.Name;
                    exists.Email = userDto.Email;
                    exists.LockoutEnd = userDto.LockoutEnd;

                    var Result = await _userManager.UpdateAsync(exists);
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
                else
                {
                    return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });
                }

            }
            catch (Exception)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
               // var User = await /*_userManager.Users.Include(s => s.Branch).Include(s => s.Repository).FirstOrDefaultAsync(p=>p.Id == Id);*/
                var User = await _userRepository.GetByIdAsync(Id);
                if (User != null)
                {
                    var user = _mapper.Map<UserDto>(User);
                    var roles = await _userManager.GetRolesAsync(User);
                    user.Role =_mapper.Map<List<RoleDto>>(roles);
                    return Ok(_mapper.Map<UserDto>(User));
                }
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.NotFound), Status = ResponseStatus.NotFound });

            }
            catch (Exception)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUserName(string UserName)
        {
            try
            {
                var CheckUser = await _userManager.FindByNameAsync(UserName);
                if (CheckUser != null)
                {
                    var userdto = _mapper.Map<UserDto>(CheckUser);
                    return Ok(userdto);
                }
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices]RoleManager<Role> roleManager)
        {
            try
            {
               
                var Users = await _userRepository.Entities.Include(s => s.Branch).Include(s => s.Repository).ToListAsync();
                return Ok(_mapper.Map<List<UserDto>>(Users));
            }
            catch (Exception)
            {
                return BadRequest(new ResultIdentity { Message = EnumExtensions.GetEnumDescription(ResponseStatus.ServerError), Status = ResponseStatus.ServerError });

            }
        }



    }
}
