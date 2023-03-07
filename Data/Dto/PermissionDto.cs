using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class PermissionDto
    {
        public Guid? Id { get; set; }

        [Display(Name ="عنوان")] 
        public string Title { get; set; }

        [Display(Name = "مسیر")]
        public string Url { get; set; }

        public bool IsMenu { get; set; }

        [Display(Name = "منو  ")]
        public int? SubCode { get; set; }

        public int Code { get; set; }
        public bool IsChecked { get; set; }
    }
}
