using Core.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Index(nameof(BankId), nameof(DegreeId))]
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }


        public Guid BankId { get; set; }
        //[ForeignKey(nameof(BankId))]
        //public virtual Bank Bank { get; set; }

        public string Manager { get; set; }
        public string Deputy { get; set; }

        public Guid AreaCode { get; set; }
        [ForeignKey(nameof(AreaCode))]
        public virtual RegionCode RegionCode { get; set; }
        public string Area { get; set; }

        public Guid BranchManagerCode { get; set; }
        [ForeignKey(nameof(BranchManagerCode))]
        public virtual BranchManager BranchManager { get; set; }
        public Guid DegreeId { get; set; }
        public Guid BranchAddressId { get; set; }
        [ForeignKey(nameof(BranchAddressId))]
        public virtual Address BranchAddress { get; set; }
        public bool isEnable { get; set; }
    }
}
