using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class BranchManagerRepository : Repos<BranchManager>, IBranchManagerRepository
    {
        public BranchManagerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
