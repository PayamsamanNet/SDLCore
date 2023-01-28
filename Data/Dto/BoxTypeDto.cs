using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class BoxTypeDto : BaseEntity
    {
        [Display(Name="عنوان ")]
        [Required(ErrorMessage ="وارد کردن  {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "ظرفیت ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public double Capacity { get; set; }
        [Display(Name = "ارتفاع ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public int Height { get; set; }
        [Display(Name = "عرض ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public int Width { get; set; }
        [Display(Name = "عمق ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public int Depth { get; set; }

        [Display(Name = "قیمت ماهانه ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public decimal MonthlyPriceRatio { get; set; }
        [Display(Name = "نسبت قیمت ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public decimal TrustPriceRatio { get; set; }
        [Display(Name = "قیمت مسدود شده ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]
        public decimal BlockedPriceRatio { get; set; }
        [Display(Name = "قیمت در حال ")]
        [Required(ErrorMessage = "وارد کردن  {0}الزامی است ")]

        public decimal? RunningPrice { get; set; }
        [Display(Name = "قیمت  کوتاه مدت  ")]
        public decimal? ShortDatePrice { get; set; }
        [Display(Name = "قیمت  دراز مدت  ")]
        public decimal? LongDatePrice { get; set; }
    }
}
