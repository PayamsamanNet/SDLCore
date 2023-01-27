using Core.Base;
using Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class RepositoryColumn : BaseEntity
    {

       
        public int Number { get; set; }
        public ColumnTypes ColumnTypes { get; set; }
        public int FromBoxNumber { get; set; }
        public int ToBoxNumber { get; set; }
        public Guid ColumnStyleId { get; set; }
        public Guid ColumnTypeId { get; set; }
        public Guid RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public virtual Repository Repository { get; set; }

    }
}
