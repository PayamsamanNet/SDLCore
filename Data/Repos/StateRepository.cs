using Core.Entities;
using Data.Context;
using Data.Interfaces;

namespace Data.Repos
{
    public class StateRepository : Repos<State>, IStateRepository
    {
        public StateRepository(SDLDbContext dbContext) : base(dbContext)
        {
        }


    }
}
