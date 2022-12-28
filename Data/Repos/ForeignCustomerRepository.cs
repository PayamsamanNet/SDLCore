using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class ForeignCustomerRepository : Repos<ForeignCustomer>, IForeignCustomerRepository
    {
        public ForeignCustomerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
