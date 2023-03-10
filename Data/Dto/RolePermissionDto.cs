using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class RolePermissionDto
    {
        public string RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}
