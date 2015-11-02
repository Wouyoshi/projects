namespace Qwixx.Models.Shared
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class GameIntention
    {
        private readonly ConcurrentQueue<string> _incomingPlayers;
        private readonly ConcurrentQueue<string> _outgoingPlayers;

        private readonly List<string> _players;

        public string Host { get; private set; }
        public int MaxPlayers { get; private set; }

        public string GameName { get; private set; }

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
            _players = new List<string> { host };
            _incomingPlayers = new ConcurrentQueue<string>();
            _outgoingPlayers = new ConcurrentQueue<string>();

            MaxPlayers = maxPlayers;
            Host = host;
            GameName = gameName;
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

        public void Join(string player)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new ArgumentNullException("player");
            }
            _incomingPlayers.Enqueue(player);
        }

        public void Leave(string player)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new ArgumentNullException("player");
            }
            _outgoingPlayers.Enqueue(player);
        }

    }
}
