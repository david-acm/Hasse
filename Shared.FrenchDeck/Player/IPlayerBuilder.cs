namespace Shared.CardGame.Player
{
	public interface IPlayerBuilder<TPlayer>
		where TPlayer : IPlayer
	{
		IPlayerBuilder<TPlayer> WithName(string name);

		TPlayer Build();
	}
}