using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

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
			var builder = new HasseGameBuilder(new TeamBuilderFactory(new PlayerBuilder()));

			builder
				.WithTeam("Colombia",
					team => team
						.WithPlayer(p => p.WithName(Player1Name))
						.WithPlayer(p => p.WithName(Player2Name)))
				.WithTeam("America",
					team => team
						.WithPlayer(p => p.WithName(Player3Name))
						.WithPlayer(p => p.WithName(Player4Name)));

			return builder.Build();
		}
	}
}