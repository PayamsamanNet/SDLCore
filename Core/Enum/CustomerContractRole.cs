using System.ComponentModel;

namespace Core.Enum
{
    public enum CustomerContractRole
    {
        [Description("مالک اصلی")]
        MainOwner = 1,

        [Description("سایر صاحبان")]
        OtherOwner = 2,

        [Description("وکیل")]
        Lawyer = 3,
    }
}
