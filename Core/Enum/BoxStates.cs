using System.ComponentModel;

namespace Core.Enum
{
    public enum BoxStates
    {
        [Description("تکنیکال برنامه نویسی")]
        TechnicalProgramming = 0,

        [Description("آزاد")]
        Green = 1,

        [Description("اجاره رفته")]
        Blue = 2,

        [Description("بلوکه شده")]
        Red = 3,

        [Description("خارج از سرویس")]
        Service = 4

    }
}
