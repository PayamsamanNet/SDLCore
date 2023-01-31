using Core.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Repository : BaseEntity
    {
      
        public string Name { get; set; }
        public string Code { get; set; }
        public string ManagerName { get; set; }
        public string TopPlanImage { get; set; }
        public string TopPlanDetails { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? OperationDate { get; set; }





        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }

        public Guid? DegreeId { get; set; }
        [ForeignKey(nameof(DegreeId))]
        public virtual Degree Degree { get; set; }








    }
}
