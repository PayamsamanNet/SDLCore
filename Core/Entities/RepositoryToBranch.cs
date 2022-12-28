using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    // [Index(nameof(RepositoryId), nameof(BranchId))]
    public class RepositoryToBranch : BaseEntity
    {

        public Guid RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public virtual Repository Repository { get; set; }


        public Guid BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        public bool IsAllowed { get; set; }
    }
}
