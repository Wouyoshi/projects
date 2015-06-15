using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class LineNumber
    {
        public string Number { get; private set; }
        public bool Checked { get; private set; }
        
        public LineNumber(string number)
        {
            this.Number = number;
        }
        public void Check()
        {
            if (Checked)
            {
                throw new InvalidOperationException("LineNumber is already checked.");
            }
            Checked = true;
        }
    }
}
