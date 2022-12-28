using Core.Base;

namespace Core.Entities
{
    public class Degree : BaseEntity
    {
        public string Name { get; set; }
        public decimal MonthlyPriceRatio { get; set; }
        public decimal TrustPriceRatio { get; set; }
        public decimal BlockedPriceRatio { get; set; }
        public bool IsUsed { get; set; }
    }
}
