using Core.Base;
using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Data.Dto
{
    public class AddressDto 
    {
        public Guid? Id { get; set; }
        [Display(Name = " آدرس پستی  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string PostalAddress { get; set; }
        [Display(Name = " فکس ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string TellPrefix { get; set; }
        [Display(Name = " فکس ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Tell { get; set; }
        [Display(Name = " موبایل  ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Mobile { get; set; }
        [Display(Name = " کد پستی   ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string PostalCode { get; set; }
        [Display(Name = " ایمیل   ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public string Email { get; set; }
        [Display(Name = " شهر   ")]
        [Required(ErrorMessage = "وارد کردن {0}الزامی است ")]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City? City { get; set; }
    }
}
