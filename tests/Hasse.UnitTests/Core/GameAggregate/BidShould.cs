using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Exceptions;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class BidShouldShould : BaseGameTest
	{
		[Fact]
		public void ThrowExceptionIfBidIsUnderPermittedValue()
		{
			// Prepare
			_hasseGame.Bid(new Bid(_hasseGame.Players[0], Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<BidUnderPermittedException>(() => _hasseGame.Bid(new Bid(_hasseGame.Players[0], Bid.Values.Four)));
		}

		[Fact]
		public void ThrowExceptionIfPlayerAlreadyBid()
		{
			// Prepare
			_hasseGame.Bid(new Bid(_hasseGame.Players[0], Bid.Values.Four));

			// Action


			// Assert
			Assert.Throws<AlreadyBidException>(() => _hasseGame.Bid(new Bid(_hasseGame.Players[0], Bid.Values.Five)));
		}

		[Fact]
		public void RecordBidIfValid()
		{
			// Prepare
			var four = new Bid(_hasseGame.Players[0], Bid.Values.Four);
			_hasseGame.Bid(four);

			// Action


			// Assert
			var five = new Bid(_hasseGame.Players[1], Bid.Values.Five);
			_hasseGame.Bid(five);

			Assert.Collection(
				_hasseGame.Biddings,
				b => Assert.Equal(b, four),
				b => Assert.Equal(b, five));
		}

		[Fact]
		public void ThrowExceptionIfNotThePlayersTurn()
		{
			
		}

	}
}