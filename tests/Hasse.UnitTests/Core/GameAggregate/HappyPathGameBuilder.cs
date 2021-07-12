using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Builders;
using Hasse.SharedKernel;
using Shared.CardGame.Player;
using Shared.TwoTeamsCardGame;
using Shared.TwoTeamsCardGame.Team;
using static Shared.TwoTeamsCardGame.DiagonalTeamPlayer.TablePosition;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public sealed class HappyPathGameBuilder : LazyBuilder<Game, HappyPathGameBuilder>
	{
		public const string David = "David";
		public const string Allison = "Allison";
		public const string Greta = "Greta";
		public const string Joe = "Joe";

		protected override Game Construct()
		{
			var gameBuilder = new HasseGameBuilder<DiagonalTeamPlayer, HassePlayerBuilder>(new TeamBuilderFactory<DiagonalTeamPlayer, HassePlayerBuilder>(new HassePlayerBuilder()));
			

			gameBuilder
				.WithTeam("Colombia",
					team => team
						.WithPlayer(p => p
							.WithPosition(One)
							.WithName(David))
						.WithPlayer(p => p
							.WithName(Allison)
							.WithPosition(Two)))
				.WithTeam("America",
					team => team
						.WithPlayer(p => p
							.WithName(Greta)
							.WithPosition(Three))
						.WithPlayer(p => p
							.WithName(Joe)
							.WithPosition(Four)))
				.WithDealer(Two);

			return gameBuilder.Build();
		}
	}
}