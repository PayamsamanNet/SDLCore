using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class RegionCodeRepository : Repos<RegionCode>, IRegionCodeRepository
    {
        public RegionCodeRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
