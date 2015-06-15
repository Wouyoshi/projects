using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Line : IEnumerable<LineNumber>
    {
        private readonly IList<LineNumber> lineNumbers;
        public Ordering Ordering { get; private set; }

        public Color Color { get; private set; }

        

        public Line(Color color)
        {
            if (color == null)
            {
                throw new ArgumentNullException("color");
            }

            var lineNumbers = new List<LineNumber>() { };
            IList<string> numbers = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            var ordering = Ordering.Ascending;
            if (color == Color.Green || color == Color.Blue)
            {
                ordering = Models.Ordering.Descending;
                numbers = (IList<string>)numbers.Reverse();
            }
            numbers.Add("lock");
            foreach (var number in numbers)
            {
                lineNumbers.Add(new LineNumber(number));
            }

            this.lineNumbers = lineNumbers;
            this.Ordering = ordering;
            this.Color = color;
        }
        public Line(IList<LineNumber> lineNumbers, Ordering ordering, Color color)
        {
            if (lineNumbers == null)
            {
                throw new ArgumentNullException("lineNumbers");
            }
            if (color == null)
            {
                throw new ArgumentNullException("color"); 
            }

            this.lineNumbers = lineNumbers;
            this.Ordering = ordering;
            this.Color = color;
        }

        public LineNumber this[int i]
        {
            get { return lineNumbers[i]; }
            private set { lineNumbers[i] = value; }
        }

        public IEnumerator<LineNumber> GetEnumerator()
        {
            return lineNumbers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lineNumbers.GetEnumerator();
        }
    }
}
