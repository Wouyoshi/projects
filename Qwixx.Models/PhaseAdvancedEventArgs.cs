using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class PhaseAdvancedEventArgs : EventArgs
    {
        public Phase PreviousPhase { get; private set; }
        public Phase CurrentPhase { get; private set; }
        public Turn Turn { get; private set; }

        public PhaseAdvancedEventArgs(Phase previousPhase, Phase currentPhase, Turn turn)
        {
            PreviousPhase = previousPhase;
            CurrentPhase = currentPhase;
            Turn = turn;
        }
    }
}
