using Core.Base;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Core.Entities
{
    public class SystemUser : BaseEntity
    {

        public DateTime LastLoginDate { get; set; }
        public SystemUserState SystemUserState { get; set; }
        public DateTime CreateDate { get; set; }
        #region Relations
        public Guid? RealCustomerId { get; set; }
        [ForeignKey(nameof(RealCustomerId))]
        public RealCustomer? realCustomer { get; set; }
        public Guid? LegalCustumerId { get; set; }
        public LegalCustomer LegalCustomer { get; set; }
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        #endregion
    }
}
