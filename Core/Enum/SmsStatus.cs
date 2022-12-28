using System.ComponentModel;

namespace Core.Enum
{
    public enum SmsStatus
    {
        [Description("در احال انتظار")]
        Waiting = 0,
        [Description("ارسال شد")]
        Sent = 1,
        [Description("منقضی گردید")]
        Expired = 2,
    }
}
