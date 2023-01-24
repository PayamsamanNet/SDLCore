using Core.Base;
using Core.Enum;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User:IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public GenderType Gender { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
