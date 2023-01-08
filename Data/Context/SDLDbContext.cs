using Common.Utilities;
using Core.Base;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class SDLDbContext : IdentityDbContext
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
            //modelBuilder.Entity<UserAccount>().Ignore(x => x.EmailConfirmed);
         


        }
    }
}
