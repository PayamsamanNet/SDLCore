using System.ComponentModel;

namespace Core.Enum
{
    public enum ContractStep
    {
        [Description("تکنیکال برنامه نویسی")]
        TechnicalProgramming = 0,
        [Description("ثبت اولیه")]
        PrimarySave = 1,
        [Description("تایید رئیس شعبه")]
        BranchManagerAccepted = 2,
        [Description("الصاق مستندات")]
        AttachmentAdded = 3,
        [Description("تکمیل شده")]
        ContractCompleted = 4,
        [Description("لغو شده")]
        ContractCanceled = 5,
        [Description("ثبت اولیه الحاقیه")]
        PrimaryExtentionSave = 6,
        [Description("تایید الحاقیه")]
        BranchManagerExtentionAccepted = 7,
        [Description("الصاق مستندات الحاقیه")]
        ExtentionAttachmentAdded = 8,
        [Description("الصاق مستندات تمدید")]
        RenewAttachmentAdded = 9,
        [Description("منتظر تایید برای رفع بلوکه")]
        UnblockContractAccept = 10,
        [Description("الصاق مستند برای رفع بلوکه")]
        UnblockContractAttachmentAdded = 11,
        [Description("ثبت اولیه تمدید")]
        PrimaryRenew = 12,
        [Description("تایید تمدید")]
        RenewAccept = 13,

        //new
        [Description("خاتمه یافته")]
        ContractEnded = 14,
        [Description("عودت یافته")]
        ContractBoxDelivered = 15,
        [Description("ثبت اولیه درخواست خاتمه")]
        ContractEndedRequest = 16,

        [Description("راکد")]
        ContractRaked = 17,
        [Description("منتظر پرداخت")]
        PaymentWating = 18,
    }
}
