using Shared.BiddingCardGame;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
{
	public class Hand : BiddingHand
	{
		public Hand(Game game, IPlayer dealer) : base(game, dealer)
		{

		}
	}
}