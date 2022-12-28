using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class AddressRepository : Repos<Address>, IAddressRepository
    {
        public AddressRepository(SDLDbContext dbContext) : base(dbContext)
        {

        }
    }
}
