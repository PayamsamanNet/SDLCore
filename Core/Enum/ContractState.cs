using System.ComponentModel;

namespace Core.Enum
{
    public enum ContractState
    {
        [Description("فعال")]
        Running = 1,
        [Description("انصراف")]
        Cancellation = 2,
        [Description("اتمام")]
        Ended = 3,
    }
}
