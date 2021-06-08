using System.Linq;
using Hasse.Core.GameAggregate;
using Shared.BiddingCardGame;
using Shared.CardGame;
using Shared.CardGame.Exceptions;
using Shared.TwoTeamsCardGame;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class BidShould : BaseGameTest
	{
		[Fact]
		public void ThrowExceptionIfBidIsUnderPermittedValue()
		{
			// Prepare
			Game.CurrentHand.Bid(new Bid(Game.Players.First(), Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<BidUnderPermittedException>(() => Game.CurrentHand.Bid(new Bid(Game.Players.First(), Bid.Values.One)));
		}

		[Fact]
		public void ThrowExceptionIfPlayerAlreadyBid()
		{
			// Prepare
			Game.Bid(new Bid(Game.Players.First(), Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<NotYourTurnException>(() => Game.Bid(new Bid(Game.Players.First(), Bid.Values.Five)));
		}

		[Fact]
		public void RecordBidIfValid()
		{
			// Prepare
			var playerAtTwo = new Bid(Game.Players.First(p => p.Position == DiagonalTeamPlayer.TablePosition.Two), Bid.Values.Four);
			Game.Bid(playerAtTwo);

			// Action


			// Assert
			var five = new Bid(Game.Players.Single(p => p.Position == DiagonalTeamPlayer.TablePosition.Three), Bid.Values.Five);
			Game.Bid(five);

			Assert.Collection(
				Game.CurrentHand.Bids,
				b => Assert.Equal(b, playerAtTwo),
				b => Assert.Equal(b, five));
		}

		[Fact]
		public void ThrowExceptionIfNotThePlayersTurn()
		{
			
		}
	}
}