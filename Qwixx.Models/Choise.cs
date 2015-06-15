using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Choise
    {
        public Player Player { get; private set; }
        public Card Card { get; private set; }
        public Line Line { get; private set; }
        public LineNumber LineNumber { get; private set; }
        public bool IsColoredDieChoise { get; private set; }
        public bool IsWastedChoise { get; private set; }
        public Die Die1 { get; private set; }
        public Die Die2 { get; private set; }

        public Choise(Player player, Card card, Line line, LineNumber lineNumber, Die die1, Die die2, bool isWastedChoise)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (card == null)
            {
                throw new ArgumentNullException("card");
            }
            if (line == null)
            {
                throw new ArgumentNullException("line");
            }
            if (lineNumber == null)
            {
                throw new ArgumentNullException("lineNumber");
            }
            if (die1 == null)
            {
                throw new ArgumentNullException("die1");
            }
            if (die2 == null)
            {
                throw new ArgumentNullException("die2");
            }
            if (die1.Color != Color.White && die2.Color != Color.White)
            {
                throw new ArgumentException("One die color must be white.");
            }
            Player = player;
            Card = card;
            Line = line;
            LineNumber = lineNumber;
            IsColoredDieChoise = die1.Color != Color.White || die2.Color != Color.White;
            IsWastedChoise = isWastedChoise;
        }

    }
}
