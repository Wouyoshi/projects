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

        private readonly IList<Turn> turns;

        public Game(IList<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException("players");
            }
            var dice = new List<Die>() {
                new Die(Color.White),
                new Die(Color.White),
                new Die(Color.Red),
                new Die(Color.Yellow),
                new Die(Color.Green),
                new Die(Color.Blue)
            };
            Dice = new Dice(dice);
        }

        public IEnumerator<Turn> GetEnumerator()
        {
            return turns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return turns.GetEnumerator();
        }

        public Turn this[int i]
        {
            get { return turns[i]; }
            private set { turns[i] = value; }
        }
    }
}
