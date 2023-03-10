using Core.Entities;

namespace Data.Interfaces
{
    public interface IAddressRepository : IRepos<Address>
    {
       Task<Address> SaveAndReturnId(Address address);

    }
}
