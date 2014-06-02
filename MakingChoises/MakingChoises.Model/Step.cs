using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChoises.Model
{
    public class Step
    {
        public int Number { get; set; }
        public IList<Problem> Problems { get; set; }
    }
}
