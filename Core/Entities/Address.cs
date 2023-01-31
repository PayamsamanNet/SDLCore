using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public string PostalAddress { get; set; }
        public string TellPrefix { get; set; }
        public string Tell { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }
    }
}
