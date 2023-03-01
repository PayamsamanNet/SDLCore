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
    public class PermissionRepository : Repos<Permission>, IPermissionRepository
    {
        public PermissionRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
