using System;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Shared.TwoTeamsCardGame.Team
{
	public sealed class TeamBuilder<TPlayer, TPlayerBuilder> 
		: LazyBuilder<Team, TeamBuilder<TPlayer, TPlayerBuilder>>,
			ITeamBuilder<TPlayer, TPlayerBuilder>
		where TPlayer : IPlayer
		where TPlayerBuilder : BasePlayerBuilder<TPlayer>
	{
		private readonly TPlayerBuilder _playerBuilder;
		private (IPlayer, IPlayer) _players;

		public TeamBuilder(string name, TPlayerBuilder playerBuilder) : this(playerBuilder)
		{
			Guard.Against.NullOrWhiteSpace(name, nameof(name));

			WithName(name);
		}

		public TeamBuilder(TPlayerBuilder playerBuilder)
		{
			Guard.Against.Null(playerBuilder, nameof(playerBuilder));

			_playerBuilder = playerBuilder;
		}

		public ITeamBuilder<TPlayer, TPlayerBuilder> WithPlayer(Action<TPlayerBuilder> builder)
		{
			builder(_playerBuilder);

			var player = _playerBuilder.Build();

			AddPlayer(player);

			return this;
		}

		public ITeamBuilder<TPlayer, TPlayerBuilder> WithName(string name)
		{
			Do(t => t.Name = name);

			return this;
		}

		private void AddPlayer(IPlayer player)
		{
			if (_players.Item1 is null)
				_players.Item1 = player;
			else if (_players.Item2 is null)
				_players.Item2 = player;
		}

		protected override Team Construct()
		{
			return new(_players);
		}
	}
}