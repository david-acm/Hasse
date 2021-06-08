using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Hasse.SharedKernel;
using Shared.CardGame;
using Shared.CardGame.Player;
using Shared.TwoTeamsCardGame;
using Shared.TwoTeamsCardGame.Team;

namespace Hasse.Core.GameAggregate.Builders
{
	public class
		HasseGameBuilder<TPlayer, TPlayerBuilder> : LazyBuilder<Game,
			HasseGameBuilder<TPlayer, TPlayerBuilder>>
		where TPlayer : IPlayer
		where TPlayerBuilder : BasePlayerBuilder<TPlayer>
	{
		private readonly ITeamBuilderFactory<TPlayer, TPlayerBuilder> _teamBuilderFactory;
		protected (Team, Team) _teams;

		public HasseGameBuilder(ITeamBuilderFactory<TPlayer, TPlayerBuilder> teamBuilderFactory)
		{
			_teamBuilderFactory = teamBuilderFactory;
		}

		public DiagonalTeamPlayer.TablePosition DealerPosition { get; set; }

		public HasseGameBuilder<TPlayer, TPlayerBuilder> WithTeam(string name,
			Action<ITeamBuilder<TPlayer, TPlayerBuilder>> actions)
		{
			var teamBuilder = _teamBuilderFactory.GetTeamBuilder(name);

			actions(teamBuilder);

			var team = teamBuilder.Build();

			AddTeam(team);

			return this;
		}

		protected override Game Construct()
		{
			var dealer = _teams.Item1.Players.Union(_teams.Item2.Players)
				.FirstOrDefault(p => ((DiagonalTeamPlayer)p).Position == DealerPosition);

			return new(_teams.Item1, _teams.Item2, dealer);
		}

		private void AddTeam(Team team)
		{
			if (_teams.Item1 is null)
				_teams.Item1 = team;
			else if (_teams.Item2 is null)
				_teams.Item2 = team;
		}
	}

	public static class CardGameTeamBuilderExtensions
	{
		public static HasseGameBuilder<DiagonalTeamPlayer, HassePlayerBuilder> WithDealer(this HasseGameBuilder<DiagonalTeamPlayer, HassePlayerBuilder> builder, DiagonalTeamPlayer.TablePosition position)
		{
			builder.DealerPosition = position;

			return builder;
		}
	}
}