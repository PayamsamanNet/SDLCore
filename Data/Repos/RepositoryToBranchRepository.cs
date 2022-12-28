using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class RepositoryToBranchRepository : Repos<RepositoryToBranch>, IRepositoryToBranchRepository
    {
        public RepositoryToBranchRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
