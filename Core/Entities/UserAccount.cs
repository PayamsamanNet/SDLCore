using Core.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserAccount : BaseEntity /*IdentityUser*/
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
