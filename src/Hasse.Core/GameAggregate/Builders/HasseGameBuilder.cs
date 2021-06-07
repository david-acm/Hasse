using System.Linq;
using Hasse.Core.GameAggregate.Team;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Builders
{
	public class HasseGameBuilder 
		: CardGameTeamBuilder<HasseGameBuilder, DiagonalTeamPlayer, HassePlayerBuilder>
	{
		private static readonly TeamBuilderFactory<DiagonalTeamPlayer, HassePlayerBuilder> TeamBuilderFactory =
			new(new HassePlayerBuilder());

		public DiagonalTeamPlayer.TablePosition DealerPosition { get; set; }

		public HasseGameBuilder() : base(TeamBuilderFactory)
		{
		}

		protected override HasseGame Construct()
		{
			var dealer = _teams.Item1.Players.Union(_teams.Item2.Players)
				.FirstOrDefault(p => ((DiagonalTeamPlayer) p).Position == DealerPosition);

			return new(_teams.Item1, _teams.Item2, dealer);
		}
	}

	public static class HasseGameBuilderExtensions
	{
		public static HasseGameBuilder WithDealer(this HasseGameBuilder builder, DiagonalTeamPlayer.TablePosition position)
		{
			builder.DealerPosition = position;

			return builder;
		}
	}
}