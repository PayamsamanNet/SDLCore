using Core.Base;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class CustomerDto /*: BaseEntity*/
    {
        public Guid? Id { get; set; }

        [MaxLength(16)]
        public string IdCard { get; set; }
        public string IbanId { get; set; }

        public Guid BranchId { get; set; }
        public Guid? FromBranchId { get; set; }
        public string? AccountDescription { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Guid BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public BankDto Bank { get; set; }

        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public AddressDto Address { get; set; }

        public Guid CustomerTypeId { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        public CustomerTypeDto CustomerType { get; set; }

        public Guid ForeignCustomerId { get; set; }
        [ForeignKey(nameof(ForeignCustomerId))]
        public ForeignCustomerDto? ForeignCustomer { get; set; }

        public Guid LegalCustomerId { get; set; }
        [ForeignKey(nameof(LegalCustomerId))]
        public LegalCustomerDto? LegalCustomer { get; set; }

        public Guid RealCustomerId { get; set; }
        [ForeignKey(nameof(RealCustomerId))]
        public RealCustomerDto? RealCustomer { get; set; }

        public string TypeCustomer { get; set; }
    }
}
