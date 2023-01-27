using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class DegreeDto : BaseEntity
    {
        [Display(Name="عنوان ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "نسبت قیمت ماهانه ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public decimal MonthlyPriceRatio { get; set; }
        [Display(Name = "قیمت ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public decimal TrustPriceRatio { get; set; }
        [Display(Name = "قیمت مسدود شده ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public decimal BlockedPriceRatio { get; set; }
        [Display(Name = "استفاده شده  ")]
        public bool IsUsed { get; set; }
    }
}
