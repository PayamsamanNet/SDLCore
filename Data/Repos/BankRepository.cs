using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class BankRepository : Repos<Bank>, IBankRepository
    {
        public BankRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
