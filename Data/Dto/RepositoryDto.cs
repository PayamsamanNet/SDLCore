using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class RepositoryDto 
    {
        public Guid? Id { get; set; }
        [Display(Name="نام ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "کد  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Code { get; set; }
        [Display(Name = "مدیریت  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string ManagerName { get; set; }
        [Display(Name = "تصویر ")]
       
        public string? TopPlanImage { get; set; }
        [Display(Name = "جزئیات")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string TopPlanDetails { get; set; }

        public DateTime? InstallationDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? OperationDate { get; set; }

        public Guid AddressId { get; set; }
        public AddressDto? Address { get; set; }


        [Display(Name = "بانک")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid BankId { get; set; }
        public virtual BankDto? Bank { get; set; }

        [Display(Name = "درجه")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid? DegreeId { get; set; }
        [ForeignKey(nameof(DegreeId))]
        public virtual DegreeDto? Degree { get; set; }
    }
}
