using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class BranchManagerDto : BaseEntity
    {
        [Display(Name ="نام ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string BranchManagerCode { get; set; }
        [Display(Name = "کد ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string BranchManagerName { get; set; }
    }
}
