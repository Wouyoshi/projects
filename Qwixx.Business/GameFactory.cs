namespace Qwixx.Business
{
    using System.Collections.Generic;
    using Models;

    public class GameFactory
    {
        public static Game MakeGame(params string[] names)
        {
            var players = new List<Player>();
            foreach (var name in names)
            {
                var player = new Player(name);
                players.Add(player);
            }
            var newGame = new Game(players);
            return newGame;
        }
    }
}
