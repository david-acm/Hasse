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
		public const string Player1Name = "David";
		public const string Player2Name = "Allison";
		public const string Player3Name = "Greta";
		public const string Player4Name = "Joe";

		protected override Game Construct()
		{
			var gameBuilder = new HasseGameBuilder<DiagonalTeamPlayer, HassePlayerBuilder>(new TeamBuilderFactory<DiagonalTeamPlayer, HassePlayerBuilder>(new HassePlayerBuilder()));
			

			gameBuilder
				.WithTeam("Colombia",
					team => team
						.WithPlayer(p => p
							.WithPosition(One)
							.WithName(Player1Name))
						.WithPlayer(p => p
							.WithName(Player2Name)
							.WithPosition(Two)))
				.WithTeam("America",
					team => team
						.WithPlayer(p => p
							.WithName(Player3Name)
							.WithPosition(Three))
						.WithPlayer(p => p
							.WithName(Player4Name)
							.WithPosition(Four)))
				.WithDealer(Two);

			return gameBuilder.Build();
		}
	}
}