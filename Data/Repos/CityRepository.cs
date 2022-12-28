using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class CityRepository : Repos<City>, ICityRepository
    {
        public CityRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
