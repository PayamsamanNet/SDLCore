using Core.Entities;
using Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepository:IRepos<User>
    {
        Task<List<UserDto>> GetAll();
    }
}
