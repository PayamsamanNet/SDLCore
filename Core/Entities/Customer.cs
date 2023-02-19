using Core.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Customer : BaseEntity
    {
        [MaxLength(16)]
        public string IdCard { get; set; }
        public string IbanId { get; set; }
        public Guid BranchId { get; set; }
        public string? AccountDescription { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
      
        public Guid BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }

        public Guid CustomerTypeId { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        public CustomerType CustomerType { get; set; }


        public Guid ForeignCustomerId { get; set; }
        [ForeignKey(nameof(ForeignCustomerId))]
        public ForeignCustomer? ForeignCustomer { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }


        public Guid LegalCustomerId { get; set; }
        [ForeignKey(nameof(LegalCustomerId))]
        public LegalCustomer? LegalCustomer { get; set; }

        public Guid RealCustomerId { get; set; }
        [ForeignKey(nameof(RealCustomerId))]
        public RealCustomer? RealCustomer { get; set; }

    }
}
