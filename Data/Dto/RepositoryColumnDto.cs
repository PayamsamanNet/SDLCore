using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class RepositoryColumnDto : BaseEntity
    {

        public Guid RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public virtual RepositoryDto Repository { get; set; }
        public int Number { get; set; }
        public ColumnTypes ColumnTypes { get; set; }
        public int FromBoxNumber { get; set; }
        public int ToBoxNumber { get; set; }
        public Guid ColumnStyleId { get; set; }
        public Guid ColumnTypeId { get; set; }

    }
}
