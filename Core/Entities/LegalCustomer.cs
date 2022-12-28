using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{

    public class LegalCustomer : BaseEntity
    {
        [MaxLength(11)]
        //      [Key, ForeignKey(nameof(Customer))]
        public Guid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Customer Customer { get; set; }
        public string CompanyName { get; set; }
        public string RegisterNumber { get; set; }
        public string OfficialGazetteNumber { get; set; }
        public DateTime? OfficialGazetteDate { get; set; }
        public DateTime? lastVisitDate { get; set; }
        public CompanyType CompanyType { get; set; }

    }
}

