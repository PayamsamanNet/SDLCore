using Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int CityCode { get; set; }

        public Guid StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; }
    }

    #region Fluent API

    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.CityCode).IsRequired(true);
            builder.Property(c=> c.StateId).IsRequired(true);
        }
    }

    #endregion
}
