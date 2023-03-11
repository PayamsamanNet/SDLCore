using Core.Base;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{

    public class AgreementDto
    {
        public Guid? Id { get; set; }
        public string ContractNumber { get; set; }

        public Guid? CustomerId { get; set; }

        public CustomerDto CustomerDto { get; set; }


        public CustomerContractRole CustomerRole { get; set; }
        public ContractType ContractType { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public Guid? InsuranceId { get; set; }
        [ForeignKey(nameof(InsuranceId))]
        public InsuranceDto Insurance { get; set; }

        public Guid BoxId { get; set; }
        public BoxDto Box { get; set; }

        public Guid BranchId { get; set; }

        public string? Description { get; set; }

        public string? BlockDescription { get; set; }

        public int? CountEntry { get; set; }

        public string? UnBlockDescription { get; set; }

        public string? CancelDescription { get; set; }

        public ContractState ContractState { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public decimal MonthlyPrice { get; set; }
        public int? BlockedNumber { get; set; }
        public decimal TrustPrice { get; set; }

        public string? ContractScanImage { get; set; }
        public string? ContractExtScanImage { get; set; }

        public BoxStates LastBoxState { get; set; }

        public ContractStep ContractStep { get; set; }

        public string? MifareCardNumber { get; set; }
        public string? MifareRegistrationId { get; set; }
        public bool? MifareRestart { get; set; }
        public bool? GateWasOpened { get; set; }
        public DateTime? GateWasOpenedAt { get; set; }
        public decimal? BlockedPrice { get; set; }
        public string? UnblockContractImage { get; set; }
        public ContractStep? LastContractStep { get; set; }
        public ContractBlockType? ContractBlockType { get; set; }

        public int? WholeEntrance { get; set; }
        public int? UsedEntrance { get; set; }

    }
}
