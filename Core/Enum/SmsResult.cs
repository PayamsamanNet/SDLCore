using System.ComponentModel;

namespace Core.Enum
{
    public enum SmsResult
    {

        [Description("موفق")]
        Succes = 1,

        [Description("شماره موبایل نامعتبر")]
        InvalidMobileNumber = 2,

        [Description("عدم دسترسی")]
        AccessDenied = 3,

        [Description("اشکال در سیستم")]
        SystemError = 4,

        [Description("خارج از ظرفیت انتقال")]
        NotEnoughQuota = 5,

        [Description("اشکال ")]
        CatchError = 6,

        [Description("هنوز ارسال نشده است")]
        NotSentYet = 7,

        [Description("اشکال ناشناخته")]
        UnknownError = 8,
    }
}
