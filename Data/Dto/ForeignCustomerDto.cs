using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{

    public class ForeignCustomerDto 
    {
        public Guid? Id { get; set; }
        [Display(Name = "شماره پاسپورت  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string PassportNum { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Surname { get; set; }
        [Display(Name = " نام پدر  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string FatherName { get; set; }
        [Display(Name = "محل تولد  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string BirthPlace { get; set; }
        [Display(Name = "تاریخ تولد  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string BirthDate { get; set; }
        [Display(Name = "جنیست  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public GenderType Gender { get; set; }

    }
}
