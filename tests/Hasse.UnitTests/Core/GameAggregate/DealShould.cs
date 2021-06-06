using Hasse.Core.GameAggregate;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class DealShould : BaseGameTest
	{
		[Fact]
		public void DealShouldGive6CardsToEachPlayer()
		{
			_hasseGame.Deal();
			_hasseGame.Deal();

			Assert.All(
				_hasseGame.Players,
				p => Assert.Equal(6, p.Hand.Count));
		}
		
		[Fact]
		public void DeckShouldBeEmptyAfterDeal()
		{
			_hasseGame.Deal();

			Assert.Empty(_hasseGame.Deck.Cards);
		}
	}

	public class BaseGameTest
	{
		protected readonly HasseGame _hasseGame;

		protected BaseGameTest()
		{
			_hasseGame = new HappyPathGameBuilder();
		}
	}
}