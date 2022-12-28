using Core.Base;
using Core.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Index(nameof(BranchId), nameof(RepositoryId))]
    public class Log : BaseEntity
    {
        public Level Level { get; set; }
        public LogType LogType { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Machine { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Extra { get; set; }

        //       public virtual Branch Branch { get; set; }
        public Guid? BranchId { get; set; }

        //       public virtual Repository Repository { get; set; }
        public Guid? RepositoryId { get; set; }

        //  public virtual User User { get; set; }
        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Agreement Contract { get; set; }
    }
}
