using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
{
	public class Bid
	{
		public Bid(IPlayer player, Values value)
		{
			Player = player;
			Value = value;
		}

		public IPlayer Player { get; }
		public Values Value { get; }

		public enum Values
		{
			One,
			Two,
			Three,
			Four,
			Five,
			Six,
			Hasse,
			DoubleHasse
		}
	}
}