using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Player
    {
        public Card Card { get; private set; }
        public string Name { get; private set; }

        public Player(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
        }
        public void GiveNewCard()
        {
            Card = new Card();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            var other = obj as Player;
            if (other == null)
            {
                return false;
            }
            return other.Name == this.Name;
        }
    }
}
