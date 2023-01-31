using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class RegionCodeDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }
        [Display(Name ="کد ناحیه  ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string AreaCode { get; set; }




        [Display(Name = "  نام ناحیه ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string AreaName { get; set; }


    }
}
