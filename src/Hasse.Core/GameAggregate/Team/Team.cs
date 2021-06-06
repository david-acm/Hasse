using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
    public class Team : BaseGameEntity
    {
        private readonly List<IPlayer> _players = new();

        internal Team((IPlayer, IPlayer) players)
        {
            Guard.Against.Null(players, nameof(players));
            Guard.Against.Null(players.Item1, "players.Item1");
            Guard.Against.Null(players.Item2, "players.Item2");

            _players.Add(players.Item1);
            _players.Add(players.Item2);
        }

        public string Name { get; internal set; }

        public IReadOnlyCollection<IPlayer> Players => _players;

        public override IPrototype DeepCopy()
        {
            var player1 = (IPlayer) _players.ElementAt(0).DeepCopy();
            var player2 = (IPlayer) _players.ElementAt(1).DeepCopy();

            return new Team((player1, player2));
        }

        public override string ToString() => $"{_players[0]} and {_players[1]}";
    }
}