using Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class UserAccountDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }

        [Display(Name = "نام کاربری")]
        
        public string UserName { get; set; }

        [Display(Name ="رمز وزود")]
        public string Password { get; set; }
    }
}
