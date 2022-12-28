using Core.Base;

namespace Core.Entities
{
    public class CustomerType : BaseEntity
    {
        public Guid BankId { get; set; }
        public string TypeName { get; set; }

        public decimal MonthlyPriceRatio { get; set; }
        public decimal TrustPriceRatio { get; set; }
        public decimal BlockedPriceRatio { get; set; }
        public int EntranceRatio { get; set; }
        public int EntrancePackagePrice { get; set; }
    }
}
