using Common.Utilities;
using Core.Base;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class SDLDbContext : IdentityDbContext<User,Role,string>
    {
        public SDLDbContext(DbContextOptions<SDLDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var Assmebly = typeof(IEntity).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(Assmebly);
            modelBuilder.RegisterEntityTypeConfiguration(Assmebly);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            //modelBuilder.Entity<UserAccount>().Ignore(x => x.EmailConfirmed);
        }
    }
}
