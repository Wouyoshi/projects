namespace Qwixx.DataAccess
{
    using System;

    using Models;

    public interface IGameStorage
    {
        Game Get(Guid id);
        void Add(Game game);
        void Update(Game game);
        void Delete(Guid id);
    }
}
