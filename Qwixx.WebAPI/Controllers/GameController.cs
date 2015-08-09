using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qwixx.Models;

namespace Qwixx.WebAPI.Controllers
{
    using DataAccess;

    public class GameController : ApiController
    {

        private readonly IGameStorage _gameStorage;

        public GameController(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }
        public IEnumerable<Game> Get()
        {
            return null;
        }

        public Game Get(Guid id)
        {
            var game = _gameStorage.Get(id);
            return game;
        }
        
        public void Post([FromBody]Game game)
        {
            _gameStorage.Add(game);
        }

        public void Put(Guid id, [FromBody]Game game)
        {
            _gameStorage.Update(game);
        }

        public void Delete(Guid id)
        {
            _gameStorage.Delete(id);
        }
    }
}
