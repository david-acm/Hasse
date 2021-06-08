using System;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;
using Shared.TwoTeamsCardGame;
using Shared.TwoTeamsCardGame.Team;

namespace Hasse.Core.GameAggregate.Builders
{
    public class HasseTeamBuilder : LazyBuilder<Team, HasseTeamBuilder>
    {
        private (DiagonalTeamPlayer, DiagonalTeamPlayer) _players;
        private readonly HassePlayerBuilder _playerBuilder;

        public HasseTeamBuilder(string name, HassePlayerBuilder playerBuilder)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            Do(t => t.Name = name);

            _playerBuilder = playerBuilder;
        }

        protected override Team Construct()
        {
            return new(_players);
        }

        public HasseTeamBuilder WithPlayer(Action<HassePlayerBuilder> builder)
        {
            builder(_playerBuilder);

            var player = _playerBuilder.Build();

            AddPlayer(player);

            return this;
        }
		
        private void AddPlayer(DiagonalTeamPlayer player)
        {
            if (_players.Item1 is null)
                _players.Item1 = player;
            else if (_players.Item2 is null)
                _players.Item2 = player;
        }
    }
}