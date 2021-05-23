using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate.Team
{
    public class Team : BaseGameEntity
    {
        private readonly List<Player.Player> _players = new();

        internal Team((Player.Player, Player.Player) players)
        {
            Guard.Against.Null(players, nameof(players));
            Guard.Against.Null(players.Item1, "players.Item1");
            Guard.Against.Null(players.Item2, "players.Item2");

            _players.Add(players.Item1);
            _players.Add(players.Item2);
        }

        public string Name { get; internal set; }

        public IReadOnlyCollection<Player.Player> Players => _players;

        public override IPrototype DeepCopy()
        {
            var player1 = (Player.Player) _players.ElementAt(0).DeepCopy();
            var player2 = (Player.Player) _players.ElementAt(1).DeepCopy();

            return new Team((player1, player2));
        }
    }
}