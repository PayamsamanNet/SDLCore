using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class LogRepository : Repos<Log>, IlogRepository
    {
        public LogRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
