using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class AgreementDetailDto /*: BaseEntity*/ 
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public AgreementDto Contract { get; set; }

        public Guid CustomerId { get; set; }

        public CustomerContractRole CustomerContractRole { get; set; }

        public bool IsLawyer { get; set; }

    }
}
