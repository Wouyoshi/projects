

namespace Qwixx.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using Qwixx.Models;
    using DataAccess;

    public class GameController : ApiController
    {

        private readonly IGameIntentionStorage _gameIntentionStorage;

        public GameController(IGameIntentionStorage gameIntentionStorage)
        {
            _gameIntentionStorage = gameIntentionStorage;
        }
        public IEnumerable<Game> Get()
        {
            return null;
        }

        public Game Get(Guid id)
        {
            var gameIntention = _gameIntentionStorage.Get(id);
            if (gameIntention == null)
            {
                return null;
            }
            return gameIntention.GetGame();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameIntention"></param>
        public void Post([FromBody]Game game)
        {
            // _gameStorage.Add(game);
        }

        public void Put(Guid id, [FromBody]Game game)
        {
            //_gameStorage.Update(game);
        }

        public void Delete(Guid id)
        {
            // _gameStorage.Delete(id);
        }
    }
}
