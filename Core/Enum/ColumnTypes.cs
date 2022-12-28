using System.ComponentModel;

namespace Core.Enum
{
    public enum ColumnTypes
    {
        Unknown = 0,
        [Description("تیپ A")]
        A = 1,
        [Description("تیپ B")]
        B = 2
    }
}
