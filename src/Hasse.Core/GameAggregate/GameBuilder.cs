using System;
using Hasse.Core.GameAggregate.Player;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate
{
    public sealed class GameBuilder : LazyBuilder<HasseGame, GameBuilder>
    {
        private readonly ITeamBuilderFactory _teamBuilderFactory;
        private (Team.Team, Team.Team) _teams;

        public GameBuilder(ITeamBuilderFactory teamBuilderFactory)
        {
            _teamBuilderFactory = teamBuilderFactory;
        }

        public GameBuilder WithTeam(string name, Action<ITeamBuilder> actions)
        {
            var teamBuilder = _teamBuilderFactory.GetTeamBuilder(name);
            actions(teamBuilder);

            var team = teamBuilder.Build();

            AddTeam(team);

            return this;
        }

        protected override HasseGame Construct()
        {
            return new(_teams.Item1, _teams.Item2);
        }

        private void AddTeam(Team.Team team)
        {
            if (_teams.Item1 is null)
                _teams.Item1 = team;
            else if (_teams.Item2 is null)
                _teams.Item2 = team;
        }
    }

}