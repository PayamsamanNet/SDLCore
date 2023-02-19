using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class BranchDto 
    {
        public Guid? Id { get; set; }
        [Display(Name = "نام  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "کد ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Code { get; set; }
        [Display(Name = " مدیریت  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Manager { get; set; }
        [Display(Name = "معاون  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Deputy { get; set; }



        [Display(Name = "ناحیه  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid RegionCodeId { get; set; }
        public virtual RegionCodeDto? RegionCode { get; set; }

        [Display(Name = "مدریریت شعبه")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid BranchManagerId { get; set; }
        public virtual BranchManagerDto? BranchManager { get; set; }
        [Display(Name = " بانک")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid BankId { get; set; }
        public Bank? Bank { get; set; }

        [Display(Name = " درجه ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid DegreeId { get; set; }

        public DegreeDto? Degree { get; set; }

        public Guid BranchAddressId { get; set; }
        public virtual AddressDto? BranchAddress { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public bool isEnable { get; set; }
    }
}
