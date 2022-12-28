using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Lawyer : BaseEntity
    {
        public Guid? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public string MandateNumber { get; set; }
        public DateTime? MandateDate { get; set; }
        public DateTime? MandateStartDate { get; set; }

        public DateTime? MandateEndDate { get; set; }

        public string MandateScanImage { get; set; }

        public string MifareCardNumber { get; set; }
        public string MifareRegistrationId { get; set; }

        public bool CanOpenBox { get; set; }

        public bool? LawyerStatus { get; set; }

        //public bool? IsFromContract { get; set; }
        //public Guid? ReplacmentPersonWithLawyerID { get; set; }

        //public string ReplacmentPersonWithLawyerNationalCode { get; set; }
    }
}
