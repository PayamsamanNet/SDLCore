using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class RepositoryRepository : Repos<Repository>, IRepositoryRepository
    {
        public RepositoryRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
