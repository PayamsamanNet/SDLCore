using System.ComponentModel;

namespace Core.Enum
{
    public enum ContractBlockType
    {

        [Description("جاری")]
        RunningPrice = 1,
        [Description("کوتاه مدت")]
        ShortDatePrice = 2,
        [Description("بلند مدت")]
        LongDatePrice = 3,
        [Description("بدون مسدودی")]
        None = 0,

    }
}

