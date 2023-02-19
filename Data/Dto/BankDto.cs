using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Data.Dto
{
    public class BankDto 
    {
        public Guid? Id { get; set; }
        [Display(Name="نام ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string Name { get; set; }


    }
}
