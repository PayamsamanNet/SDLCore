using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class CustomerRepository : Repos<Customer>, ICustomerRepository
    {
        public CustomerRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
