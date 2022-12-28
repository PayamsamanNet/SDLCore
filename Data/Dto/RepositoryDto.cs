using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    [Index(nameof(AddressId))]
    public class RepositoryDto : BaseEntity
    {

        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string ManagerName { get; set; }

        //public Guid IsAllowed { get; set; }
        //[ForeignKey(nameof(IsAllowed))]
        //public RepositoryToBranch RepositoryToBranch { get; set; }  

        public Guid? DegreeId { get; set; }
        [ForeignKey(nameof(DegreeId))]
        public virtual DegreeDto Degree { get; set; }

        public Guid AddressId { get; set; }

        //[ForeignKey(nameof(AddressId))]
        //public virtual Address address { get; set; }

        public string TopPlanImage { get; set; }
        public string TopPlanDetails { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? OperationDate { get; set; }
        // public string RepositoryType { get; set; }


    }
}
