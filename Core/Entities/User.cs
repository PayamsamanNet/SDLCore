using Core.Base;
using Core.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class User:IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public GenderType Gender { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Guid? RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public Repository? Repository { get; set; }
        public Guid? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch? Branch { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }

        public List<Role> Roles { get; set; }
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(f=>f.NationalCode).HasMaxLength(10).IsUnicode(true);
        }
    }
}
