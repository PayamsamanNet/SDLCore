using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enum;

namespace Data.Dto
{
    public class RealCustomerCrud
    {
        public Guid? Id { get; set; }
        [MaxLength(16)]
        [Required]
        public string IdCard { get; set; }
        [Required]
        public string IbanId { get; set; }
        [Required]
        public Guid BranchId { get; set; }
        [Required]
        public Guid? FromBranchId { get; set; }
        [Required]
        public string? AccountDescription { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public BankDto Bank { get; set; }
        [Required]
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public AddressDto Address { get; set; }
        [Required]
        public Guid CustomerTypeId { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        public CustomerTypeDto CustomerType { get; set; }
        public Guid? RealCustomerId { get; set; }
        [MaxLength(10)]
        public string NationalCode { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Surname { get; set; }
        [Display(Name = "نام پدر  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string FatherName { get; set; }
        [Display(Name = "محل تولد ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string BirthPlace { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "جنسیت ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public GenderType Gender { get; set; }
    }
}
