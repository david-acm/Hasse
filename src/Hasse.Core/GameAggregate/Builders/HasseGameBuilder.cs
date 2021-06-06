using Hasse.Core.GameAggregate.Team;

namespace Hasse.Core.GameAggregate.Builders
{
	public class HasseGameBuilder : CardGameTeamBuilder<DiagonalTeamPlayer, HassePlayerBuilder>
	{
		private static readonly TeamBuilderFactory<DiagonalTeamPlayer, HassePlayerBuilder> TeamBuilderFactory =
			new(new HassePlayerBuilder());

		public HasseGameBuilder() : base(TeamBuilderFactory)
		{
		}
	}
}