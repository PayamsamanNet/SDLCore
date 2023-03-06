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
        public string? Password { get; set; }
        [Display(Name = "تکرار کلمه عبور ")]
        [Compare(nameof(Password),ErrorMessage = "کلمه عبور و تکرار آن مغایرت دارد ")]
        public string? RePassword { get; set; }
        [Display(Name = "رمز عبور قدیمی ")]  
        public string? OldPassword { get; set; }
        public bool IsSuccessCode { get; set; }
        public bool IsSuccessUser { get; set; }
        public bool SendEmail { get; set; }
        public bool SendMobail { get; set; }
        [Display(Name = "نام کاربری ")]
        public string? UserName { get; set; }
        public string? Code { get; set; }
        [Display(Name = "  کد اعتبار سنجی  ")]
        [Compare(nameof(Code))]
        public string? UserCode { get; set; }
    }
}
