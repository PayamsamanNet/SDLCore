using Core.Entities;
using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Authentication
{
    public interface IJwtRepository
    {
        ResponseAccount CreateToken(UserDto userDto);
    }
}
