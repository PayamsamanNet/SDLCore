using Core.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Index(nameof(BranchId))]
    public class Iban : BaseEntity
    {
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        [MaxLength(15)]
        public string AccountNum { get; set; }

        [MaxLength(24)]
        public string IbanNumber { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public string Balance { get; set; }
        [NotMapped]
        public string OwnerName { get; set; }

        public Guid BranchId { get; set; }
        public bool IsMain { get; set; }


    }
}
