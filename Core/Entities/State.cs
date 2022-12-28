using Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public int StateCode { get; set; }

    }

    #region Fluent API


    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.StateCode).IsRequired(true);
            
        }
    }

    #endregion
}
