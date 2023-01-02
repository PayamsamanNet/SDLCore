﻿using Core.Entities;
using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public interface IJwtRepository
    {
        ResponseAccount CreateToken(UserAccountDto userAccountDto);
    }
}
