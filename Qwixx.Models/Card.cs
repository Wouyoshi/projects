namespace Qwixx.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Card : IEnumerable<Line>
    {
        private readonly IList<Line> _lines;

        public int WastedRolls { get; private set; }

        public Card()
        {
            _lines = new List<Line>() {
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
            this._lines = lines;
        }

        public Line this[int i]
        {
            get { return _lines[i]; }
            private set { _lines[i] = value; }
        }

        public void AddWastedRoll()
        {
            WastedRolls++;
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return _lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lines.GetEnumerator();
        }
    }
}
