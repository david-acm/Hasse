using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
	public class TeamBuilderFactory<TPlayer, TPlayerBuilder> 
		: ITeamBuilderFactory<TPlayer, TPlayerBuilder>
			where TPlayer : IPlayer
			where TPlayerBuilder : BasePlayerBuilder<TPlayer>
	{
		private readonly TPlayerBuilder _playerBuilder;

		public TeamBuilderFactory(TPlayerBuilder playerBuilder)
		{
			_playerBuilder = playerBuilder;
		}

		public ITeamBuilder<TPlayer, TPlayerBuilder> GetTeamBuilder(string name)
		{
			return new TeamBuilder<TPlayer, TPlayerBuilder>(name, _playerBuilder);
		}
	}
}