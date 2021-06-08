using System;
using System.Collections.Generic;
using System.Linq;
using Shared.CardGame;
using Shared.CardGame.Exceptions;
using Shared.CardGame.Player;

namespace Shared.BiddingCardGame
{
	public abstract class BiddingHand : Hand
	{
		protected readonly List<Bid> _bids = new();

		protected BiddingHand(CardGame.CardGame game, IPlayer dealer) : base(game, dealer)
		{
		}

		public IReadOnlyList<Bid> Bids => _bids.ToList().AsReadOnly();

		public void Bid(Bid bid)
		{
			// TODO: Change to guard clause
			ValidateBid(bid);

			_bids.Add(bid);

			RotateQueue();
		}

		private void ValidateBid(Bid bid)
		{
			try
			{
				var noBids = !Bids.Any();
				var underLastBids = Bids.Any(b => b.Value >= bid.Value);
				var notYourTurn = _turns.Peek().Player != bid.Player;

				if (noBids) return;
				if (underLastBids) throw new BidUnderPermittedException();
				if (notYourTurn) throw new NotYourTurnException();
			}
			catch (BidUnderPermittedException e)
			{
				Console.WriteLine(e);
				throw;
			}
			catch (NotYourTurnException e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}