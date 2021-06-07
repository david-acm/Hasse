using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Builders
{
	public class
		CardGameTeamBuilder<TSelf, TPlayer, TPlayerBuilder> : LazyBuilder<HasseGame,
			CardGameTeamBuilder<TSelf, TPlayer, TPlayerBuilder>>
		where TSelf : CardGameTeamBuilder<TSelf, TPlayer, TPlayerBuilder>
		where TPlayer : IPlayer
		where TPlayerBuilder : BasePlayerBuilder<TPlayer>
	{
		private readonly ITeamBuilderFactory<TPlayer, TPlayerBuilder> _teamBuilderFactory;
		protected (Team.Team, Team.Team) _teams;

		public CardGameTeamBuilder(ITeamBuilderFactory<TPlayer, TPlayerBuilder> teamBuilderFactory)
		{
			_teamBuilderFactory = teamBuilderFactory;
		}

		public TSelf WithTeam(string name,
			Action<ITeamBuilder<TPlayer, TPlayerBuilder>> actions)
		{
			var teamBuilder = _teamBuilderFactory.GetTeamBuilder(name);

			actions(teamBuilder);

			var team = teamBuilder.Build();

			AddTeam(team);

			return (TSelf)this;
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