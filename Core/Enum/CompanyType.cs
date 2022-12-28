using System.ComponentModel;

namespace Core.Enum
{
    public enum CompanyType
    {
        [Description("دولتی")]
        State = 1,

        [Description("مسئولیت محدود")]
        limitedLiabilityCompany = 2,

        [Description("سهامی خاص")]
        PrivateLimitedCompany = 3,

        [Description("تعاونی")]
        CooperationCompany = 4,

        [Description("سهامی عام")]
        LLPCompany = 5,

        [Description("مختلط سهامی و غیر سهامی")]
        JointStockAndNonStockCompany = 6,

        [Description("تضامنی")]
        PartnershipCompany = 7,

        [Description("غیر تجاری")]
        NonCommercialCompany = 8


    }
}
