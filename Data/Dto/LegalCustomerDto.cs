using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{

    public class LegalCustomerDto
    {
        public Guid? Id { get; set; }
        [Display(Name = "نام شرکت  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string CompanyName { get; set; }
        [Display(Name = "شماره ثبت  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string RegisterNumber { get; set; }
        [Display(Name = "شماره رسمی   ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string OfficialGazetteNumber { get; set; }
        [Display(Name = "تاریخ    ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public DateTime? OfficialGazetteDate { get; set; }
        public DateTime? lastVisitDate { get; set; }
        [Display(Name = "نوع شرکت     ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public CompanyType CompanyType { get; set; }

    }
}

