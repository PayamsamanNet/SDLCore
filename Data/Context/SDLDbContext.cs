using Common.Utilities;
using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class SDLDbContext : DbContext
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
            modelBuilder.Entity<State>().Property(e => e.Id).HasDefaultValueSql("(newid())");


        }
    }
}
