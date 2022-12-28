using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class AddressDto : BaseEntity
    {
        public string PostalAddress { get; set; }
        public string TellPrefix { get; set; }
        public string Tell { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }


        public Guid CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityDto City { get; set; }
    }
}
