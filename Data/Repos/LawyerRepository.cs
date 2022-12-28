using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class LawyerRepository : Repos<Lawyer>, IlawyerRepository
    {
        public LawyerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
