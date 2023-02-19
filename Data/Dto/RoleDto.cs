using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class RoleDto
    {
        public string? Id { get; set; }
        [Display(Name="عنوان ")]
        [Required(ErrorMessage ="وارد کردن {0}الزامی است ")]
        public  string Name { get; set; }
        [Display(Name = "نام نمایشی ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public  string NormalizedName { get; set; }
        [Display(Name = "مهر امنیتی  ")]
        public  string? ConcurrencyStamp { get; set; }
        [Display(Name = "توضیحات  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Description { get; set; }
        public List<RolePermission>? Permissions { get; set; }
    }
}
