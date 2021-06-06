using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Builders;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.Player;
using static Hasse.Core.GameAggregate.DiagonalTeamPlayer.TablePosition;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public sealed class HappyPathGameBuilder : LazyBuilder<HasseGame, HappyPathGameBuilder>
	{
		public const string Player1Name = "David";
		public const string Player2Name = "Allison";
		public const string Player3Name = "Greta";
		public const string Player4Name = "Joe";

		protected override HasseGame Construct()
		{
			var gameBuilder = new HasseGameBuilder();

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
							.WithPosition(Four)));

			return gameBuilder.Build();
		}
	}
}