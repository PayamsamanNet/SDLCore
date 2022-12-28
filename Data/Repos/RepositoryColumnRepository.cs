using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class RepositoryColumnRepository : Repos<RepositoryColumn>, IRepositoryColumnRepository
    {
        public RepositoryColumnRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
