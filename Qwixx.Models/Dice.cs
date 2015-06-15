using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Dice : IEnumerable<Die>
    {
        private readonly IList<Die> dice;

        public Dice(IList<Die> dice)
        {
            if (dice == null)
            {
                throw new ArgumentNullException("dice");
            }
            this.dice = dice;
        }

        public Die this[int i]
        {
            get { return dice[i]; }
            private set { dice[i] = value; }
        }

        public IEnumerator<Die> GetEnumerator()
        {
            return dice.GetEnumerator();
        }

        public void RemoveDie(Die die)
        {
            if (die == null)
            {
                throw new ArgumentNullException("die");
            }
            dice.Remove(die);
        }

        public void RollAll()
        {
            foreach(var die in dice)
            {
                die.Roll();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dice.GetEnumerator();
        }
    }
}
