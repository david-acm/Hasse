using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
	public class TeamBuilderFactory : ITeamBuilderFactory
	{
		private readonly IPlayerBuilder _playerBuilder;

		public TeamBuilderFactory(IPlayerBuilder playerBuilder)
		{
			_playerBuilder = playerBuilder;
		}

		public ITeamBuilder GetTeamBuilder(string name)
		{
			return new TeamBuilder(name, _playerBuilder);
		}
	}
}