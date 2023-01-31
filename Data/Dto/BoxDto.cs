using Core.Base;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class BoxDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string NumStr { get; set; }


        public Guid RepositoryId { get; set; }

        public Guid ColumnId { get; set; }
        [ForeignKey(nameof(ColumnId))]
        public virtual RepositoryColumnDto RepositoryColumn { get; set; }



        public Guid BoxTypeId { get; set; }
        [ForeignKey(nameof(BoxTypeId))]
        public virtual BoxTypeDto BoxType { get; set; }

        public BoxStates BoxState { get; set; }

        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsVip { get; set; }

        //public Guid? InsuranceId { get; set; } 


    }
}
