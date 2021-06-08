using Shared.CardGame.Player;

namespace Shared.CardGame
{
	public class Turn
	{
		internal Turn(IPlayer player)
		{
			Player = player;
		}

		public IPlayer Player { get; }
	}
}