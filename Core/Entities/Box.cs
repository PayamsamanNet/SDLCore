using Core.Base;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Index(nameof(RepositoryId))]
    public class Box : BaseEntity
    {
        public int Number { get; set; }
        public string NumStr { get; set; }
        public Guid ColumnId { get; set; }
        [ForeignKey(nameof(ColumnId))]
        public virtual RepositoryColumn RepositoryColumn { get; set; }
        public Guid BoxTypeId { get; set; }
        [ForeignKey(nameof(BoxTypeId))]
        public virtual BoxType BoxType { get; set; }
        public BoxStates BoxState { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsVip { get; set; }
        public Guid RepositoryId { get; set; }
        [ForeignKey(nameof(RepositoryId))]
        public Repository Repository { get; set; }


    }
}
