using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class AgreementDetail : BaseEntity
    {

        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Agreement Contract { get; set; }

        public Guid CustomerId { get; set; }

        public CustomerContractRole CustomerContractRole { get; set; }

        public bool IsLawyer { get; set; }

    }
}
