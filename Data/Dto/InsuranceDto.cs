using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class InsuranceDto 
    {
        public Guid? Id { get; set; }
        [Display(Name = "نام شرکت بیمه")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public string InsuranceCompanyName { get; set; }

        [Display(Name = " شرکت خدمات  بیمه")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public string InsuranceCompanyNameService { get; set; }

        [Display(Name = "  سقف تعهد یبمه")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public int SwearCeiling { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "  از تاریخ ")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public string StartDate { get; set; }

        [Display(Name = "تا تاریخ  ")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public string EndDate { get; set; }

        [Display(Name = "  نرخ های حق بیمه")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public int PremiumRates { get; set; }

        [Display(Name = "  مبلغ")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public decimal Amount { get; set; }
        [Display(Name = "ازمبلغ")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public decimal FromAmount { get; set; }
        [Display(Name = "  تا مبلغ ")]
        [Required(ErrorMessage = "وارد کردن  {0} اجباری است ")]
        public decimal UntilAmount { get; set; }
    }
}
