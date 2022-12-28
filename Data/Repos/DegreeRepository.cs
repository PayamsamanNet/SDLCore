using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class DegreeRepository : Repos<Degree>, IDegreeRepository
    {
        public DegreeRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
