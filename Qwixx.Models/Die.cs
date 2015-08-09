using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Die
    {
        public short Number { get; private set; }
        public Color Color { get; private set; }

        public Die(Color color)
        {
            Color = color;
        }
        
        public void Roll()
        {
            var rand = new Random();
            Number = (short)rand.Next(1, 6);
        }
    }
}
