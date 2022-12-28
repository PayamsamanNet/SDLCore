using System.ComponentModel;

namespace Core.Enum
{
    public enum TransactionType
    {
        [Description("شارژ مخزن")]
        TankCharging = 1,
        [Description("مسدودی")]
        blocking = 2,
        [Description("آزاد سازی")]
        liberation = 3,
        [Description("کسر مبلغ برای قرارداد")]
        ContractCost = 4,
        [Description("دریافت ودیعه")]
        ReceiveVadieh = 5,
        [Description("دریافت اجاره")]
        ReceiveEjareh = 6,
        [Description("سایر")]
        OtherTransactions = 7
    }
}
