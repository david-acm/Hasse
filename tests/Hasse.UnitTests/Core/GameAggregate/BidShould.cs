using System.Linq;
using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Exceptions;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class BidShould : BaseGameTest
	{
		[Fact]
		public void ThrowExceptionIfBidIsUnderPermittedValue()
		{
			// Prepare
			_hasseGame.CurrentHand.Bid(new Bid(_hasseGame.Players.First(), Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<BidUnderPermittedException>(() => _hasseGame.CurrentHand.Bid(new Bid(_hasseGame.Players.First(), Bid.Values.One)));
		}

		[Fact]
		public void ThrowExceptionIfPlayerAlreadyBid()
		{
			// Prepare
			_hasseGame.Bid(new Bid(_hasseGame.Players.First(), Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<NotYourTurnException>(() => _hasseGame.Bid(new Bid(_hasseGame.Players.First(), Bid.Values.Five)));
		}

		[Fact]
		public void RecordBidIfValid()
		{
			// Prepare
			var playerAtTwo = new Bid(_hasseGame.Players.First(p => p.Position == DiagonalTeamPlayer.TablePosition.Two), Bid.Values.Four);
			_hasseGame.Bid(playerAtTwo);

			// Action


			// Assert
			var five = new Bid(_hasseGame.Players.Single(p => p.Position == DiagonalTeamPlayer.TablePosition.Three), Bid.Values.Five);
			_hasseGame.Bid(five);

			Assert.Collection(
				_hasseGame.CurrentHand.Bids,
				b => Assert.Equal(b, playerAtTwo),
				b => Assert.Equal(b, five));
		}

		[Fact]
		public void ThrowExceptionIfNotThePlayersTurn()
		{
			
		}
	}
}