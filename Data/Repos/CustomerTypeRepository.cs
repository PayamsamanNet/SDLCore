using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class CustomerTypeRepository : Repos<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
