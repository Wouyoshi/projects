namespace Qwixx.DataAccess
{
    using System;
    using System.Collections.Generic;
    using Models.Shared;
    using System.Collections.Concurrent;


    public class GameIntentionCacheStorage : IGameIntentionStorage
    {
        private static readonly ConcurrentDictionary<Guid, GameIntention> Dictionary = new ConcurrentDictionary<Guid, GameIntention>(); 

        public IEnumerable<GameIntention> Get()
        {
            return Dictionary.Values;
        }

        public GameIntention Get(Guid id)
        {
            GameIntention gameIntention;
            Dictionary.TryGetValue(id, out gameIntention);
            return gameIntention;
        }

        public void Add(GameIntention gameIntention)
        {
            if (gameIntention == null)
            {
                throw new ArgumentNullException(nameof(gameIntention));
            }
            var added = Dictionary.TryAdd(gameIntention.Identifier, gameIntention);
            if (!added)
            {
                throw new GameIntentionStorageException("Could not add game intention: " + gameIntention.Identifier);
            }
        }

        public void Update(GameIntention gameIntention)
        {
            if (gameIntention == null)
            {
                throw new ArgumentNullException(nameof(gameIntention));
            }
            var existingGame = Get(gameIntention.Identifier);
            if (existingGame == null)
            {
                throw new GameIntentionStorageException("Can't update unexisting game intention: " + gameIntention.Identifier);
            }
            var updated = Dictionary.TryUpdate(gameIntention.Identifier, gameIntention, existingGame);
            if (!updated)
            {
                throw new GameIntentionStorageException("Could not update game intention: " + gameIntention.Identifier);
            }
        }

        public void Delete(Guid id)
        {
            GameIntention removedGameIntention;
            var removed = Dictionary.TryRemove(id, out removedGameIntention);
            if (!removed)
            {
                throw new GameStorageException("Could not remove game intention with id: " + id);
            }
        }
    }
}
