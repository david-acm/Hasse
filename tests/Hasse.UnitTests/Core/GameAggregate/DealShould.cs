using Hasse.Core.GameAggregate;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class DealShould : BaseGameTest
	{
		[Fact]
		public void DealShouldGive6CardsToEachPlayer()
		{
			Game.Deal();
			Game.Deal();

			Assert.All(
				Game.Players,
				p => Assert.Equal(6, p.Hand.Count));
		}
		
		[Fact]
		public void DeckShouldBeEmptyAfterDeal()
		{
			Game.Deal();

			Assert.Empty(Game.Deck.Cards);
		}
	}

	public class BaseGameTest
	{
		protected readonly Game Game;

		protected BaseGameTest()
		{
			Game = new HappyPathGameBuilder();
		}
	}
}