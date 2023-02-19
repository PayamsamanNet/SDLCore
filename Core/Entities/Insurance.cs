using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Insurance : BaseEntity
    {
        
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyNameService { get; set; }
        public int SwearCeiling { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PremiumRates { get; set; }
        public decimal Amount { get; set; }
        public decimal FromAmount { get; set; }
        public decimal UntilAmount { get; set; }

      
    }
}
