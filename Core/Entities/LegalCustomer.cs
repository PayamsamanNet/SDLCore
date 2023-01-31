using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{

    public class LegalCustomer : BaseEntity
    {
        public string CompanyName { get; set; }
        public string RegisterNumber { get; set; }
        public string OfficialGazetteNumber { get; set; }
        public DateTime? OfficialGazetteDate { get; set; }
        public DateTime? lastVisitDate { get; set; }
        public CompanyType CompanyType { get; set; }

    }
}

