using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class BranchRepository : Repos<Branch>, IBranchRepository
    {
        public BranchRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
