using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class Insurancerepository : Repos<Insurance>, IInsuranceRepository
    {
        public Insurancerepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
