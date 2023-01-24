using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class LoginDto
    {
        [Display(Name ="نام کاربری ")]
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است ")]
        public string UserName { get; set; }
        [Display(Name = "کلمه عبور  ")]
        [Required(ErrorMessage ="وارد کردن  کلمه عبور الزامی است ")]
        public string Password { get; set; }
    }
}
