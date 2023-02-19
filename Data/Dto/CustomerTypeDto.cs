using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class CustomerTypeDto 
    {
        public Guid? Id { get; set; }

       
        [Display(Name = "نوع ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public string TypeName { get; set; }
        [Display(Name = " ضریب اجاره ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public decimal MonthlyPriceRatio { get; set; }
        [Display(Name = " ضریب ودیعه ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public decimal TrustPriceRatio { get; set; }
        [Display(Name = " ضریب مسدودی ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public decimal BlockedPriceRatio { get; set; }
        [Display(Name = " ضریب ورودی ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public int EntranceRatio { get; set; }
        [Display(Name = " ضریب بسته ورودی ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public int EntrancePackagePrice { get; set; }

        [Display(Name = "بانک ")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است ")]
        public Guid BankId { get; set; }

        public BankDto? Bank { get; set; }
    }
}
