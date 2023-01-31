using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    //[Index(nameof(BoxId))]
    public class InsuranceDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }
        [Display(Name = "نام شرکت بیمه")]
        [Required(ErrorMessage = "وارد کردن نام شرکت بیمه اجباری است ")]
        public string InsuranceCompanyName { get; set; }

        [Display(Name = " شرکت خدمات  بیمه")]
        public string InsuranceCompanyNameService { get; set; }

        [Display(Name = "  سقف تعهد یبمه")]
        public int SwearCeiling { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "  از تاریخ ")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تا تاریخ  ")]
        public DateTime EndDate { get; set; }

        [Display(Name = "  نرخ های حق بیمه")]
        public int PremiumRates { get; set; }

        [Display(Name = "  مبلغ")]
        public decimal Amount { get; set; }
        [Display(Name = "ازمبلغ")]

        public decimal FromAmount { get; set; }
        [Display(Name = "  تا مبلغ ")]
        public decimal UntilAmount { get; set; }

        //public Guid? BoxId { get; set; }
        //[ForeignKey(nameof(BoxId))]
        //public Box Box { get; set; }
        //[Display(Name = " کاربر ثبت کننده  ")]
        //public Guid? CretedByUserId { get; set; }
    }
}
