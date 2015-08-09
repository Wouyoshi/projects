using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Game : IEnumerable<Turn>
    {
        public IList<Player> Players { get; private set; }
        public Dice Dice { get; private set; }
        public Guid Identifier { get; private set; }

        private readonly IList<Turn> _turns;

        public Game(IList<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException("players");
            }
            Players = players;
            var dice = new List<Die>() {
                new Die(Color.White),
                new Die(Color.White),
                new Die(Color.Red),
                new Die(Color.Yellow),
                new Die(Color.Green),
                new Die(Color.Blue)
            };
            Dice = new Dice(dice);
            Identifier = Guid.NewGuid();
            _turns = new List<Turn>();
        }

        public IEnumerator<Turn> GetEnumerator()
        {
            return _turns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _turns.GetEnumerator();
        }

        public Turn this[int i]
        {
            get { return _turns[i]; }
            private set { _turns[i] = value; }
        }
    }
}
