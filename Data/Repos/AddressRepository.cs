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
        public async Task<Address> SaveAndReturnId(Address address)
        {
            try
            {
               var ID = Guid.NewGuid();
                address.Id = ID;
                await Entities.AddAsync(address);
                await DbContext.SaveChangesAsync();
                return address;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
