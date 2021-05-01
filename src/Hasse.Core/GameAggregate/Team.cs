using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Ardalis.GuardClauses;

namespace Hasse.Core.GameAggregate
{
    public class Team : BaseGameEntity
    {
        internal Team(Player player1, Player player2)
        {
            Guard.Against.Null(player1, nameof(player1));
            Guard.Against.Null(player2, nameof(player2));

            _players = new List<Player> { player1, player2 };
        }

        private readonly List<Player> _players;

        public IReadOnlyCollection<Player> Players => _players;

        public override IPrototype DeepCopy()
        {
            var player1 = (Player)_players.ElementAt(0).DeepCopy();
            var player2 = (Player)_players.ElementAt(1).DeepCopy();

            return new Team(player1, player2);
        }
    }
}