using Shared.CardGame.Player;

namespace Shared.TwoTeamsCardGame.Team
{
	public interface ITeamBuilderFactory<TPlayer, out TPlayerBuilder>
		where TPlayerBuilder : BasePlayerBuilder<TPlayer>
		where TPlayer : IPlayer
	{
		ITeamBuilder<TPlayer, TPlayerBuilder> GetTeamBuilder(string name);
	}
}