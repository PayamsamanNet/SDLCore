using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class BoxTypeRepository : Repos<BoxType>, IBoxTypeRepository
    {
        public BoxTypeRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
