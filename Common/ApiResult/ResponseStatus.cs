using System.ComponentModel;

namespace Common.ApiResult
{
    public enum ResponseStatus
    {
        [Description("عملیات  مورد نظر با موفقیت انجام شد ")]
        Success = 1,
        [Description("!اطلاعات وارد شده  نا معتبر است")]
        BadRequest = 2,
        [Description("اطلاعاتی جهت نمایش یافت نشد! ")]
        NotFound = 3,
        [Description("در سیستم خطایی رخ داد! مجددا تلاش کنید ")]
        ServerError = 4,
        [Description("کاربری با اطلاعات وارد شده وجود ندارد  ")]
        NotFoundUser = 5,
    }

}
