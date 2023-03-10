using Core.Entities;
using Data.Context;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class UserRepository : Repos<User>, IUserRepository
    {
        private readonly SDLDbContext _context;
        public UserRepository(SDLDbContext dbContext) : base(dbContext)
        {
            _context= dbContext;
        }

        public async Task<List<AccessDto>> GetRoleForUser(string UserId)
        {
            try
            {
                var Roles = await (from userrole in _context.UserRoles join role in _context.Roles on userrole.UserId equals UserId
                                   join rolepermission in _context.Set<RolePermission>() on role.Id equals rolepermission.RoleId 
                                   join permission in _context.Set<Permission>() on rolepermission.PermissionId equals permission.Id
                                   select new AccessDto
                                   {
                                       Name = permission.Title,
                                       UrlPer=permission.Url,
                                       RoleName= role.Name,
                                       RoleNameShow=role.NormalizedName,
                                       RoleUrl=permission.Url,
                                       ChekCode=permission.Code
                                   }).ToListAsync();
                return Roles;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public async Task<List<UserDto>> GetAll()
        {
            try
            {

                var test = await (from user in _context.Users
                                  join userrole in _context.UserRoles on user.Id equals userrole.UserId
                                  
                                  join role in _context.Roles on userrole.RoleId equals role.Id
                                  select new
                                  {
                                      name = user.Name,
                                      family = user.Family,
                                      rolename = role.Name,
                                      UserName = user.UserName,

                                  }).ToListAsync();









                var Listeee = await (from user in _context.Users
                                     join userroles in _context.UserRoles on user.Id equals userroles.UserId 
                                     join role in _context.Roles on userroles.RoleId equals role.Id
                                     select new { UserId = user.Id, Username = user.UserName, roleid = role.Id, rolename = role.Name }
                                    ).ToListAsync();

                //var eee = string.Join(","  , await (from user in _context.UserRoles.Where(d => d.UserId == "3ba2fd2a-47e6-44aa-aebb-abeb56bb2248").SelectMany(p=>p.RoleId)));
                
                //var Listeee = await (from user in _context.Users
                //                     join userroles in _context.UserRoles on user.Id equals userroles.UserId
                //                     join role in _context.Roles on userroles.RoleId equals role.Id

                //                     select new { UserId = user.Id, Username = user.UserName, roleid = role.Id, rolename = role.Name  }
                //                    ).ToListAsync();

                return new List<UserDto>();

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
