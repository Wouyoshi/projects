namespace Qwixx.DataAccess
{
    using System;
    using System.Collections.Concurrent;
    using Models;

    public class GameCacheStorage : IGameStorage
    {
        private static readonly ConcurrentDictionary<Guid, Game> Dictionary = new ConcurrentDictionary<Guid, Game>();
        
        public Game Get(Guid id)
        {
            Game returnValue;
            Dictionary.TryGetValue(id, out returnValue);
            return returnValue;
        }

        public void Add(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            var added = Dictionary.TryAdd(game.Identifier, game);
            if (!added)
            {
                throw new GameStorageException("Could not add game: " + game.Identifier);
            }
        }

        public void Update(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            var existingGame = Get(game.Identifier);
            if (existingGame == null)
            {
                throw new GameStorageException("Can't update unexisting game: " + game.Identifier);
            }
            var updated = Dictionary.TryUpdate(game.Identifier, game, existingGame);
            if (!updated)
            {
                throw new GameStorageException("Could not update game: " + game.Identifier);
            }
        }

        public void Delete(Guid id)
        {
            Game removedGame;
            var removed = Dictionary.TryRemove(id, out removedGame);
            if (!removed)
            {
                throw new GameStorageException("Could not remove game with id: " + id);
            }
        }
    }
}
