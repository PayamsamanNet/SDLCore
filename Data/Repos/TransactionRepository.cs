using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class TransactionRepository : Repos<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
