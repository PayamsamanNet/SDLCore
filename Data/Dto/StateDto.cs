using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class StateDto 
    {
        
        public Guid? Id { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "کد ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public int StateCode { get; set; }

    }
}
