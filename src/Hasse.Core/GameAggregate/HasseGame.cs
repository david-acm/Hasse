using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate.Exceptions;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public class HasseGame : TwoTeamsCardGame
	{
		private static readonly DeckFactory DeckFactory = new PennDeckFactory<HasseGame>();
		private readonly List<Bid> _bids = new();

		internal HasseGame(Team.Team team1, Team.Team team2)
			: base(team1, team2, DeckFactory)
		{
			Players.ForEach(p => p.CurrentGame = this);
		}

		public IReadOnlyList<Bid> Biddings => _bids.AsReadOnly();

		public override IPrototype DeepCopy()
		{
			var team1 = (Team.Team) Teams.ElementAt(0)?.DeepCopy();
			var team2 = (Team.Team) Teams.ElementAt(1)?.DeepCopy();

			return new HasseGame(team1, team2);
		}

		public void Bid(Bid bid)
		{
			// TODO: Change to guard clause
			ValidateBid(bid);

			_bids.Add(bid);
		}

		private void ValidateBid(Bid bid)
		{
			try
			{
				var noBiddings = !Biddings.Any();
				var underLastBiddings = Biddings.Any(b => b.Value >= bid.Value);
				var alreadyBid = Biddings.Any(b => b.Player == bid.Player);

				if (noBiddings) return;
				if (underLastBiddings) throw new BidUnderPermittedException();
				if (alreadyBid) throw new AlreadyBidException();
			}
			catch (BidUnderPermittedException e)
			{
				Console.WriteLine(e);
				throw;
			}
			catch(AlreadyBidException e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}