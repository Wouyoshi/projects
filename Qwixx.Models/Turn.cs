using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qwixx.Models
{
    public class Turn
    {
        public Player RollingPlayer { get; private set; }
        public IList<Player> OtherPlayers { get; private set; }
        public Dice Dice { get; private set; }
        public Phase Phase { get; private set; }
        public IList<Player> FinishedPlayers { get; private set; }

        public event PhaseAdvancedEventHandler PhaseAdvanced;

        private IList<Choise> choises;

        public Turn(Player rollingPlayer, IList<Player> otherPlayers, Dice dice)
        {
            if (rollingPlayer == null)
            {
                throw new ArgumentNullException("rollingPlayer");
            }
            if (otherPlayers == null)
            {
                throw new ArgumentNullException("otherPlayers");
            }
            if (dice == null)
            {
                throw new ArgumentNullException("dice");
            }
            if (otherPlayers.Any(op => op.Equals(rollingPlayer)))
            {
                throw new ArgumentException("rollingPlayer may not be other player");
            }
            RollingPlayer = rollingPlayer;
            OtherPlayers = otherPlayers;
            Dice = dice;
            Phase = Models.Phase.NotStarted;
            choises = new List<Choise>();
            FinishedPlayers = new List<Player>();
        }
        public void Start()
        {
            if (Phase != Models.Phase.NotStarted)
            {
                throw new InvalidOperationException("Turn has already been started.");
            }
            AdvancePhase();
        }
        public void RollDice(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            if (Phase != Models.Phase.NotStarted)
            {
                throw new InvalidOperationException("Dice have already been rolled.");
            }
            if (!player.Equals(RollingPlayer))
            {
                throw new InvalidOperationException("Player is not rolling player.");
            }
            Dice.RollAll();
            AdvancePhase();
        }
        public void Choose(Choise choise)
        {
            if (choise == null)
            {
                throw new ArgumentNullException("choise");
            }
            if (Phase != Phase.Choise)
            {
                throw new InvalidOperationException("Can not choose in this phase.");
            }
            var playerChoises = choises.Where(c => c.Player.Equals(choise.Player));
            if (playerChoises.Count() != 0)
            {
                // Only the rolling player is allowed 2 choises.
                if (!choise.Player.Equals(RollingPlayer))
                {
                    throw new InvalidOperationException("Player has already made a choise this turn.");
                }
                if (choise.IsWastedChoise)
                {
                    throw new InvalidOperationException("Player can not add a wasted choise after already choosing.");
                }
                else if (playerChoises.Any(c => c.IsColoredDieChoise == choise.IsColoredDieChoise))
                {
                    throw new InvalidOperationException("Player has already made that type of choise this turn.");
                }
            }

            // Check if choise is allowed.
            if (!OtherPlayers.Equals(choise.Player) && !RollingPlayer.Equals(choise.Player))
            {
                throw new InvalidOperationException("Not a valid player.");
            }
           

            var player = OtherPlayers.FirstOrDefault(op => op.Equals(choise.Player));
            if (player == null)
            {
                player = RollingPlayer;
                if (choise.IsWastedChoise)
                {
                    // No need for more checking.
                    choises.Add(choise);
                    return;
                }
            }
            else if (choise.IsWastedChoise)
            {
                throw new InvalidOperationException("Only rolling player can add a wasted choise.");
            }



            // Check if color is not closed. (die is not removed)
            if (Dice.All(d => d.Color != choise.Line.Color))
            {
                throw new InvalidOperationException("That color is closed.");
            }

            var line = player.Card.FirstOrDefault(l => l.Color == choise.Line.Color);
            if (line == null)
            {
                throw new InvalidOperationException("That line doesn't exist.");
            }

            var lineNumber = line.FirstOrDefault(ln => ln.Number == choise.LineNumber.Number);
            if (lineNumber == null)
            {
                throw new InvalidOperationException("That line number doesn't exist.");
            }
            if (lineNumber.Checked)
            {
                throw new InvalidOperationException("That line number has already been checked.");
            }

            // Loop to gather validation statistics
            var beforeChecked = true;
            var countChecked = 0;

            for (int i = 0; i < line.Count(); i++)
            {

                if (line[i].Number == lineNumber.Number)
                {
                    beforeChecked = false;
                }
                if (!line[i].Checked)
                {
                    continue;
                }
                // Here it's checked.
                if (beforeChecked)
                {
                    countChecked++;
                }
                else
                {
                    throw new InvalidOperationException("It's not allowed to check line numbers smaller than already checked line numbers.");
                }
            }

            if (countChecked < 5 && lineNumber.Number == "lock")
            {
                throw new InvalidOperationException("Can not lock unless there are 5 line numbers checked.");
            }
            


            if (lineNumber.Number != "lock")
            {

            }
            // End loop to gather validation statistics

            // Apparently it's a valid choise. Wow.
            lineNumber.Check();
            choises.Add(choise);
        }

        public void FinishedChoise(Player finishedPlayer)
        {
            if (finishedPlayer == null)
            {
                throw new ArgumentNullException("player");
            }
            if (Phase != Models.Phase.Choise)
            {
                throw new InvalidOperationException("Can not choose in this phase.");
            }
            
            var player = OtherPlayers.FirstOrDefault(op => op.Equals(finishedPlayer));
            if (player == null)
            {
                if (!finishedPlayer.Equals(RollingPlayer))
                {
                    throw new InvalidOperationException("Not a valid player.");
                }
                player = RollingPlayer;
                if (choises.Count(c => c.Player.Equals(player)) == 0)
                {
                    throw new InvalidOperationException("Rolling player must at least do one choise.");
                }
            }
            if (FinishedPlayers.All(fp => !fp.Equals(player)))
            {
                throw new InvalidOperationException("Player already finished.");
            }
            FinishedPlayers.Add(player);
            if (FinishedPlayers.Count == OtherPlayers.Count() + 1)
            {
                AdvancePhase();
            }
        }

        private void AdvancePhase()
        {
            Phase previousePhase = Phase;
            switch(Phase)
            {
                case Phase.NotStarted:
                    Phase = Phase.DiceRolling;
                    break;
                case Phase.DiceRolling:
                    Phase = Phase.Choise;
                    break;
                case Phase.Choise:
                    Phase = Phase.TurnEnd;
                    break;
                default:
                    throw new InvalidOperationException("Phase is not in a correct state.");
            }
            PhaseAdvanced(this, new PhaseAdvancedEventArgs(previousePhase, Phase, this));
        }
    }
}
