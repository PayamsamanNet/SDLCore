using Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RolePermission:BaseEntity
    {
        public string RoleId { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        [ForeignKey(nameof(PermissionId))]
        public  Permission Permission { get; set; }
    }
}
