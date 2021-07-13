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
		public bool BiddingFinished => _bids.Count == Turns.Count;

		protected readonly List<Bid> _bids = new();

		protected BiddingHand(CardGame.CardGame game, IPlayer dealer) : base(game, dealer)
		{
		}

		public IReadOnlyList<Bid> Bids => _bids.ToList().AsReadOnly();

		public IPlayer CurrentPlayer => _turns.Peek().Player;

		public void Bid(Bid bid)
		{
			// TODO: Change to guard clause
			if(bid.Value != default)
				ValidateBid(bid);

			_bids.Add(bid);
			RotateQueue();

			if (!BiddingFinished)
			{
				return;
			}

			Winner = _bids.OrderByDescending(b => b.Value).First().Player;

			do
			{
				RotateQueue();
			} while (CurrentPlayer != Winner);
		}

		private IPlayer Winner { get; set; }

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