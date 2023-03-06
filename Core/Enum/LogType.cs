using System.ComponentModel;

namespace Core.Enum
{
    public enum LogType
    {
        Nothing = 0,

        [Description("ورود به سیستم")]
        Login = 1,
        [Description("خروج از سیستم")]
        Logout = 2,
        [Description("ثبت شعبه")]
        CreateBranch = 3,
        [Description("ویرایش شعبه")]
        UpdateBranch = 4,
        [Description("حذف شعبه")]
        DeleteBranch = 5,
        [Description("ثبت مخزن")]
        CreateRepository = 6,
        [Description("ویرایش مخزن")]
        UpdateRepository = 7,
        [Description("ویرایش تنظیمات مخزن")]
        UpdateRepositorySetting = 8,
        [Description("حذف مخزن")]
        DeleteRepository = 9,
        [Description("ثبت استان")]
        CreateState = 10,
        [Description("ویرایش استان")]
        UpdateState = 11,
        [Description("حذف استان")]
        DeleteState = 12,
        [Description("ثبت شهر")]
        CreateCity = 13,
        [Description("ویرایش شهر")]
        UpdateCity = 14,
        [Description("حذف شهر")]
        DeleteCity = 15,
        [Description("ویرایش قالب قرارداد حقیقی")]
        UpdateHaghighiTemplate = 16,
        [Description("ویرایش قالب قرارداد ")]
        UpdateTemplate = 160,
        [Description("ویرایش قالب قرارداد حقوقی")]
        UpdateHoghooghiTemplate = 17,
        [Description("ویرایش قالب قرارداد همکار")]
        UpdateHamkarTemplate = 18,
        [Description("ثبت نوع صندوق")]
        CreateBoxType = 19,
        [Description("ویرایش نوع صندوق")]
        UpdateBoxType = 20,
        [Description("حذف نوع صندوق")]
        DeleteBoxType = 21,
        [Description("ثبت صندوق در مخزن")]
        AddBoxInRepository = 22,
        [Description("ویرایش چیدمان صندوق ها در مخزن")]
        UpdateRepositoryLayout = 23,
        [Description("حذف صندوق از مخزن")]
        DeleteBoxFromRepository = 24,
        [Description("ویژه کردن صندوق")]
        BoxIsVip = 25,
        [Description("غیر ویژه کردن صندوق")]
        BoxNotVip = 26,

        [Description("ثبت مشتری")]
        CreateCustomer = 27,
        [Description("ویرایش مشتری")]
        UpdateCustomer = 28,
        [Description("حذف مشتری")]
        DeleteCustomer = 29,

        [Description("ثبت نوع مشتری")]
        CreateCustomerType = 271,
        [Description("ویرایش نوع مشتری")]
        UpdateCustomerType = 281,
        [Description("حذف نوع مشتری")]
        DeleteCustomerType = 291,

        [Description("ثبت قرارداد")]
        CreateAgreement = 30,
        [Description("پرداخت مبالغ  قرارداد")]
        PaymentContract = 5623,
        [Description("تایید قرارداد")]
        AcceptAgreement = 55,
        [Description("ویرایش قرارداد")]
        UpdateAgreement = 31,
        [Description("حذف قرارداد")]
        DeleteAgreement = 32,
        [Description("چاپ قرارداد")]
        PrintAgreement = 33,
        [Description("تمدید قرارداد")]
        RenewAgreement = 34,
        [Description("بلوکه کردن قرارداد")]
        BlockAgreement = 35,
        [Description("از حالت بلوکه خارج کردن قرارداد")]
        UnBlockAgreement = 36,
        [Description("لغو قرارداد و آزاد سازی صندوق")]
        CancelAgreement = 37,
        [Description("اتمام قرارداد و آزاد سازی صندوق")]
        EndAgreement = 3737,
        [Description("تحویل صندوق از مشتری")]
        DeliveredBox = 3738,
        [Description("ثبت درخواست اتمام قرارداد")]
        EndAgreementRequest = 3739,

        [Description("ثبت کاربر")]
        CreateUser = 38,
        [Description("ویرایش کاربر")]
        UpdateUser = 39,
        [Description("حذف کاربر")]
        DeleteUser = 40,

        [Description("تغییر کلمه عبور")]
        UpdatePassword = 41,

        [Description("تلاش نا موفق جهت باز کردن صندوق")]
        FailOnOpenBox = 42,
        [Description("باز کردن صندوق به صورت الکترونیکی")]
        OpenBoxElectronically = 431,
        //[Description("باز کردن صندوق به صورت الکترونیکی")]
        //OpenBoxElectronicallyEx = 1431,
        [Description("صندوق به صورت اجباری باز شده است")]
        OpenBoxForced = 432,
        [Description("صندوق به مدت طولانی باز مانده است")]
        OpenBoxTooLong = 433,
        [Description("باز کردن صندوق")]
        OpenBox = 43,
        //[Description("باز کردن صندوق")]
        //OpenBoxEx = 1043,
        [Description("بستن صندوق")]
        CloseBox = 44,
        [Description("تحت سرویس بردن صندوق")]
        ServiceBox = 45,
        [Description("از حالت سرویس خارج کردن صندوق")]
        UnServiceBox = 46,
        [Description("باز کردن دستی صندوق")]
        OpenBoxManually = 47,
        [Description("بستن دستی صندوق")]
        CloseBoxManually = 48,
        [Description("ثبت اثر انگشت کاربر")]
        SaveUserFingersData = 49,
        [Description("ثبت مجدد اثر انگشت کاربر")]
        RenewUserFingersData = 492,
        [Description("شناسایی انگشت کاربر")]
        VerifyUserFingersData = 491,
        [Description("تکمیل اثر انگشت صاحبان در قرارداد")]
        CompleteContractFingersData = 50,
        [Description("درخواست ثبت مجدد اثر انگشت مشتری")]
        FingerPrintRenewRequest = 501,
        [Description("تایید درخواست ثبت مجدد اثر انگشت مشتری")]
        FingerPrintRenewRequestAccept = 502,

        [Description("تغییر قیمت گذاری پایه")]
        ChangePricePolicy = 51,

        [Description("ایجاد درجه بندی")]
        CreateDegree = 52,
        [Description("ویرایش درجه بندی")]
        UpdateDegree = 53,

        [Description("ایجاد تیپ ستون")]
        CreateColumStyle = 5556,
        [Description("ویرایش تیپ ستون")]
        UpdateColumStyle = 5557,
        [Description("حذف تیپ ستون")]
        DeleteStyle = 5558,
        [Description("ایجاد ردیف در ستون")]
        CreateColumStyleDetail = 5559,
        [Description("ویرایش ردیف در ستون")]
        UpdateColumStyleDetail = 5560,

        [Description("ثبت الحاقیه")]
        PrimarySaveExtension = 54,
        [Description("ویرایش الحاقیه")]
        ExtentionContractEdit = 541,
        [Description("الصاق مستند")]
        AttachDoc = 551,
        [Description("الصاق مستند برای رفع بلوکه")]
        UnblockContractAttachmentAdded = 56,
        [Description("الصاق مستندات تمدید")]
        RenewAttachmentAdded = 57,
        [Description("الصاق مستندات الحاقیه")]
        ExtentionAttachmentAdded = 58,
        [Description("ارسال پیامک اعلان اتمام قرارداد")]
        SendExpiredContractSms = 59,
        [Description("تفییر صندوق به حالت سرویس")]
        SaveSpoiledBox = 60,
        [Description("تفییر صندوق به حالت سرویس")]
        BackToNormalStateForBox = 61,
        [Description("عزل وکیل")]
        CancelLawyer = 62,
        [Description("تایید تمدید قرارداد")]
        AcceptRenew = 63,
        [Description("تایید الحاقیه قرارداد")]
        AcceptExtentionContract = 64,
        [Description("حذف درجه بندی")]
        DeleteDegree = 65,
        [Description("افزودن اطلاعات پایه عمومی")]
        AddBasicInfo = 700,
        [Description("ویرایش اطلاعات پایه عمومی")]
        UpdateBasicInfo = 701,
        [Description("حذف اطلاعات پایه عمومی")]
        DeleteBasicInfo = 702,


        [Description("دریافت اطلاعات از کور بانک")]
        GetCoreBankInfo = 1000,

        [Description("شارژ ورود وخروج قرارداد ")]
        CreateEntrance = 1010,


        [Description("تایید تردد /حفاظت فیزیکی ")]
        EnteranceVerifyFisicalGaurd = 1011,
    }
}
