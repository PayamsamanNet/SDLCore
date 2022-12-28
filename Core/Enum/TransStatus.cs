using System.ComponentModel;

namespace Core.Enum
{
    public enum TransStatus
    {
        [Description("نا موفق")]
        Failed = 1,
        [Description("موفق")]
        Success = 0,
        [Description("نا مشخص ")]
        Unknown = 2,
    }
}
