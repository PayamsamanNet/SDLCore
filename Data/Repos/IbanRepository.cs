using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class IbanRepository : Repos<Iban>, IIbanRepository
    {
        public IbanRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
