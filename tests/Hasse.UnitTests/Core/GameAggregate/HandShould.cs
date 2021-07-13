using System.Linq;
using Hasse.Core.GameAggregate;
using Shared.BiddingCardGame;
using Shared.CardGame.Player;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class HandShould
	{
		private ITestOutputHelper _logger;
		private readonly Game _game;

		public HandShould(ITestOutputHelper logger)
		{
			_logger = logger;

			_game = new HappyPathGameBuilder();
		}

		[Fact]
		public void TurnsQueueWithBiddingWinnerFirst()
		{
			// Arrange
			var winner = PlayerAtTurn(3);

			_game.Bid(new Bid(_game.CurrentHand.CurrentPlayer, Bid.Values.Three));
			_game.Bid(new Bid(_game.CurrentHand.CurrentPlayer, Bid.Values.Four));
			_game.Bid(new Bid(_game.CurrentHand.CurrentPlayer, Bid.Values.Five));
			_game.Bid(new Bid(_game.CurrentHand.CurrentPlayer, default));

			var playerWithCurrentTurn = PlayerAtTurn(1);

			Assert.Equal(playerWithCurrentTurn, winner);
		}

		private IPlayer PlayerAtTurn(int turn)
		{
			return _game.CurrentHand.Turns.ElementAt(turn - 1).Player;
		}
	}
}