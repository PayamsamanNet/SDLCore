using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class AgreementRepository : Repos<Agreement>, IAgreementRepository
    {
        public AgreementRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
