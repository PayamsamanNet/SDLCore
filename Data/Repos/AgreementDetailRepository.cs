using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class AgreementDetailRepository : Repos<AgreementDetail>, IAgreementDetailRepository
    {
        public AgreementDetailRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }
    }
}
