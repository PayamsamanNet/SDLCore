using Core.Entities;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class UserDto
    {
        public string?  Id { get; set; }
        [Display(Name="نام کاربری ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public string UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        [Display(Name = " ایمیل  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public  bool EmailConfirmed { get; set; }
        [Display(Name = "کلمه عبور   ")]
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public   string? ConcurrencyStamp { get; set; }
        [Display(Name = " شماره موبایل    ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Name { get; set; }
        [Display(Name = "فامیل  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Family { get; set; }
        [Display(Name = "جنسیت   ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public GenderType Gender { get; set; }
        public DateTime LastLoginDate { get; set; }
        [Display(Name = "تکرار کلمه عبور    ")]
        [Compare(nameof(PasswordHash),ErrorMessage ="کلمه عبور و تکرار آن مغایرت دارد ")]
        public string? RePassword { get; set; }

        [Display(Name = " کدملی ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        [StringLength(10,ErrorMessage ="کد ملی وارد شده نا معتبر است ")]
        public string NationalCode { get; set; }
        [Display(Name = "وضعیت ")]
        public bool IsActive { get; set; }


        [Display(Name = " نقش کاربر")]
        public string? RoleId { get; set; }


        [Display(Name = "مخزن ")]
        public Guid? RepositoryId { get; set; } =(Guid?)null;
        public Repository? Repository { get; set; }
        [Display(Name = "شعبه ")]
        public Guid? BranchId { get; set; } = (Guid?)null;

        public Branch? Branch { get; set; }


        public List<RoleDto>? Role { get; set; }



        public string? CodeReset { get; set; }

        public bool IsChangePassword { get; set; }=false;
             
    }
}
