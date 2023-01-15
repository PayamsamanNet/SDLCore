using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Role:BaseEntity
	{

		public string Description { get; set; }

		public List<RolePermission> Permissions { get; set; }
	}
}
