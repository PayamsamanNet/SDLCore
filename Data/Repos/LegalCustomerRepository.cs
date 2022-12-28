using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class LegalCustomerRepository : Repos<LegalCustomer>, ILegalCustomerRepository
    {
        public LegalCustomerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
