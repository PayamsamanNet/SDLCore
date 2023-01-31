using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{

    public class ForeignCustomerDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }
        [MaxLength(12)]
        public Guid ForeignNatioanlID { get; set; }
        [ForeignKey(nameof(ForeignNatioanlID))]
        public CustomerDto Customer { get; set; }
        public string PassportNum { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }

    }
}
