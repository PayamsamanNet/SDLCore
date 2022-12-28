using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class BoxRepository : Repos<Box>, IBoxRepository
    {
        public BoxRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
