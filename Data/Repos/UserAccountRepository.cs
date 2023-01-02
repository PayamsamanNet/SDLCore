using Core.Entities;
using Data.Context;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class UserAccountRepository : Repos<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
