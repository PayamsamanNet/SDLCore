using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class TransactionDto : BaseEntity
    {

        public int TransNumber { get; set; }
        public int Extra { get; set; }
        public TransStatus TransStatus { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransAmnt { get; set; }
        public DateTime DateOfPayment { get; set; }
        //public Guid _UserId { get; set; }
        //public Guid ContractId { get; set; }
        //public Guid BranchId { get; set; }
        public string AccountNumber { get; set; }

        public Guid BranchId { get; set; }
        //[ForeignKey(nameof(BranchId))]
        //public virtual Branch Branch { get; set; }

        public Guid? CustomerId { get; set; }
        //[ForeignKey(nameof(CustomerId))]
        //public virtual Customer Customer { get; set; }

        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public virtual AgreementDto Contract { get; set; }
        //
    }
}
