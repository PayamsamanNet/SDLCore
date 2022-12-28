using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    // [Index(nameof(RepositoryId), nameof(BranchId))]
    public class RepositoryToBranchDto : BaseEntity
    {

        public Guid RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public virtual RepositoryDto Repository { get; set; }


        public Guid BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual BranchDto Branch { get; set; }
        public bool IsAllowed { get; set; }
    }
}
