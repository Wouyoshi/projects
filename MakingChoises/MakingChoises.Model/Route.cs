using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingChoises.Model
{
    public class Route
    {
        public IList<Condition> Conditions { get; set; }
        public Problem NextProblem { get; set; }
    }
}
