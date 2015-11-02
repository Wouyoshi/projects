namespace Qwixx.DataAccess
{
    using System;
    using Models.Shared;

    public interface IGameIntentionStorage
    {
        GameIntention Get(Guid id);
        void Add(GameIntention game);
        void Update(GameIntention game);
        void Delete(Guid id);
    }
}
