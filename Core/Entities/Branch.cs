using Core.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    //[Index(nameof(BankId), nameof(DegreeId))]
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Manager { get; set; }
        public string Deputy { get; set; }
        public Guid AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        public virtual RegionCode RegionCode { get; set; }
        public Guid BranchManagerId { get; set; }
        [ForeignKey(nameof(BranchManagerId))]
        public virtual BranchManager BranchManager { get; set; }
        public Guid DegreeId { get; set; }
        [ForeignKey(nameof(DegreeId))]
        public Degree Degree { get; set; }
        public Guid BranchAddressId { get; set; }
        [ForeignKey(nameof(BranchAddressId))]
        public virtual Address BranchAddress { get; set; }
        public bool isEnable { get; set; }




        //public Guid BankId { get; set; }
        //[ForeignKey(nameof(BankId))]
        //public Bank Bank { get; set; }
    }
}
