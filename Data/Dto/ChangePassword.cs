using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Dto
{
    public class ChangePassword
    {
        [Display(Name = "رمز عبور جدید ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        [Compare(nameof(Password),ErrorMessage = "کلمه عبور و تکرار آن مغایرت دارد ")]
        public string RePassword { get; set; }
        [Display(Name = "رمز عبور قدیمی ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string OldPassword { get; set; }
        public bool IsSuccessCode { get; set; }
        public bool IsSuccess { get; set; }
        public bool SendEmail { get; set; }
        public bool SendMobail { get; set; }

        [Display(Name = "نام کاربری ")]
        public string? UserName { get; set; }

    }
}
