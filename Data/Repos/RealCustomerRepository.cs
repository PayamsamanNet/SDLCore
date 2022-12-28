using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class RealCustomerRepository : Repos<RealCustomer>, IRealCustomerRepository
    {
        public RealCustomerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
