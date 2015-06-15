using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Card : IEnumerable<Line>
    {
        private IList<Line> lines;

        public int WastedRolls { get; private set; }

        public Card()
        {
            lines = new List<Line>() {
                new Line(Color.Red),
                new Line(Color.Yellow),
                new Line(Color.Green),
                new Line(Color.Blue),
            };
        }

        public Card(IList<Line> lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException("lines");
            }
            this.lines = lines;
        }

        public Line this[int i]
        {
            get { return lines[i]; }
            private set { lines[i] = value; }
        }

        public void AddWastedRoll()
        {
            WastedRolls++;
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lines.GetEnumerator();
        }
    }
}
