using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    [Index(nameof(IbanId), nameof(BranchId), nameof(FromBranchId), nameof(HomeAddressId), nameof(WorkAddressId),
        nameof(CustomerTypeId), nameof(LastCustomerTypeId))]
    public class CustomerDto : BaseEntity
    {
        [MaxLength(12)]
        public string IdCard { get; set; }
        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }

        public string IbanId { get; set; }
        public Guid BranchId { get; set; }
        public Guid FromBranchId { get; set; }
        public string? AccountDescription { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Guid? HomeAddressId { get; set; }
        [ForeignKey(nameof(HomeAddressId))]

        public Guid? WorkAddressId { get; set; }
        [ForeignKey(nameof(WorkAddressId))]
        public virtual Address Address { get; set; }
        public Guid CustomerTypeId { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        public CustomerTypeDto CustomerType { get; set; }

        public Guid? LastCustomerTypeId { get; set; }

    }
}
