using System.Timers;

namespace Qwixx.Models.Shared
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class GameIntention : IDisposable
    {
        private readonly ConcurrentQueue<string> _incomingPlayers;
        private readonly ConcurrentQueue<string> _outgoingPlayers;

        private readonly List<string> _players;

        /// <summary>
        /// The timer.
        /// </summary>
        private Timer _timer;


        public string Host { get; private set; }
        public int MaxPlayers { get; private set; }

        public string GameName { get; private set; }

        public Guid Identifier { get; private set; }

        public GameIntention(int maxPlayers, string host, string gameName)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (string.IsNullOrWhiteSpace(gameName))
            {
                throw new ArgumentNullException(nameof(gameName));
            }
            if (maxPlayers < 2)
            {
                throw new ArgumentException("Minimum of 2 players are required.");
            }
            if (maxPlayers > 5)
            {
                throw new ArgumentException("Maximum of 5 players are required.");
            }
            _players = new List<string> {host};
            _incomingPlayers = new ConcurrentQueue<string>();
            _outgoingPlayers = new ConcurrentQueue<string>();

            MaxPlayers = maxPlayers;
            Host = host;
            GameName = gameName;
            Identifier = Guid.NewGuid();

            // Create new timer and start it.
            _timer = new Timer(100);
            _timer.Elapsed += CheckQueues;
            _timer.Start();
        }


        /// <summary>
        /// The finalizer.
        /// </summary>
        ~GameIntention()
        {
            Dispose(false);
        }

        private void CheckQueues(object sender, ElapsedEventArgs args)
        {
            _timer.Stop();
            CheckQueues();
            _timer.Start();
        }

        private void CheckQueues()
        {
            // Empty outgoing player queue.
            string outgoingPlayer;
            while (_outgoingPlayers.TryDequeue(out outgoingPlayer))
            {
                if (_players.Contains(outgoingPlayer))
                {
                    _players.Remove(outgoingPlayer);
                }
            }

            // Empty incoming player queue.
            while (_players.Count < MaxPlayers)
            {
                string incomingPlayer;
                if (!_incomingPlayers.TryDequeue(out incomingPlayer))
                {
                    break;
                }
                if (_players.Contains(incomingPlayer))
                {
                    continue;
                }
                _players.Add(incomingPlayer);
            }

        }

        /// <summary>
        /// Player joins the queue to be joined to the game.
        /// </summary>
        /// <param name="player">The player to join.</param>
        public void Join(string player)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new ArgumentNullException(nameof(player));
            }
            _incomingPlayers.Enqueue(player);
        }

        /// <summary>
        /// Player joins the queue to leave the game.
        /// </summary>
        /// <param name="player">The player to leave the game.</param>
        public void Leave(string player)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new ArgumentNullException(nameof(player));
            }
            _outgoingPlayers.Enqueue(player);
        }

        /// <summary>
        /// Dispose the game intention.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_timer != null)
                {
                    _timer.Elapsed -= CheckQueues;
                    _timer.Dispose();
                    _timer = null;
                }
            }
        }

    }
}
