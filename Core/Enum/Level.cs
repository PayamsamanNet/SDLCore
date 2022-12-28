using System.ComponentModel;

namespace Core.Enum
{
    public enum Level
    {
        [Description("عیب یابی")]
        Debug = 0,
        [Description("اطلاع رسانی")]
        Info = 1,
        [Description("اخطار")]
        Warning = 2,
        [Description("خطا")]
        Error = 3,
        [Description("خطای بحرانی")]
        Fatal = 4
    }
}
