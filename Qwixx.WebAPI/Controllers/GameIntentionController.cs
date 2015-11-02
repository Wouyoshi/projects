namespace Qwixx.WebAPI.Controllers
{
    using DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using Models.Shared;

    public class GameIntentionController : ApiController
    {

        private readonly IGameStorage _gameStorage;

        public GameIntentionController(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }
        public IEnumerable<GameIntention> Get()
        {
            return null;
        }

        public GameIntention Get(Guid id)
        {
            return null;
        }
        
        public void Post([FromBody]GameIntention gameIntention)
        {
        }


        [HttpPost]
        public void Join(Guid id)
        {
        }

        public void Put(Guid id, [FromBody]GameIntention gameIntention)
        {
        }

        public void Delete(Guid id)
        {
            _gameStorage.Delete(id);
        }
    }
}
