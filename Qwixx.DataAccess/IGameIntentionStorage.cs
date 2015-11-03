namespace Qwixx.DataAccess
{
    using System.Collections.Generic;
    using System;
    using Models.Shared;

    public interface IGameIntentionStorage
    {
        IEnumerable<GameIntention> Get();
        GameIntention Get(Guid id);
        void Add(GameIntention game);
        void Update(GameIntention game);
        void Delete(Guid id);
    }
}
