using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{

    public class RealCustomer : BaseEntity
    {
        [MaxLength(10)]
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public GenderType Gender { get; set; }

    }
}
