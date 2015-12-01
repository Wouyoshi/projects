namespace Qwixx.WebAPI.Controllers
{
    using DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using Models.Shared;

    [RoutePrefix("api/gameintention")]
    public class GameIntentionController : ApiController
    {

        private readonly IGameIntentionStorage _gameIntentionStorage;

        public GameIntentionController(IGameIntentionStorage gameIntentionStorage)
        {
            _gameIntentionStorage = gameIntentionStorage;
        }
        
        [HttpGet]
        public IEnumerable<GameIntention> Get()
        {
            return _gameIntentionStorage.Get();
        }
        
        [HttpGet]
        public GameIntention Get(Guid id)
        {
            return _gameIntentionStorage.Get(id);
        }
        
        public void Post([FromBody]GameIntention gameIntention)
        {
            _gameIntentionStorage.Add(gameIntention);
        }


        [HttpPost]
        public IHttpActionResult Join(Guid id, string player)
        {
            var gameIntention = _gameIntentionStorage.Get(id);
            if (gameIntention == null)
            {
                return NotFound();
            }
            gameIntention.Join(player);
            return Ok();
        }

        public void Put(Guid id, [FromBody]GameIntention gameIntention)
        {
            _gameIntentionStorage.Update(gameIntention);
        }

        public void Delete(Guid id)
        {
            _gameIntentionStorage.Delete(id);
        }
    }
}
