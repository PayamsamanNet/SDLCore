using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CustomerType : BaseEntity
    {
       
        public string TypeName { get; set; }

        public decimal MonthlyPriceRatio { get; set; }
        public decimal TrustPriceRatio { get; set; }
        public decimal BlockedPriceRatio { get; set; }
        public int EntranceRatio { get; set; }
        public int EntrancePackagePrice { get; set; }

        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }
    }
}
