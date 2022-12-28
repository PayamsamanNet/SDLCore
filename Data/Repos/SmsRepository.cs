using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class SmsRepository : Repos<Sms>, ISmsRepository
    {
        public SmsRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
