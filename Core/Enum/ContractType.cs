using System.ComponentModel;

namespace Core.Enum
{
    public enum ContractType
    {
        [Description("معمولی")]
        Normal = 1,
        [Description("شرکتی")]
        Company = 2,
        [Description("داخلی")]
        Internal = 3
    }
}
