using System.Linq;
using Shared.CardGame.DeckAggregate;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.DeckAggregate
{
	public class DeckConstructorShouldShould
	{
		private readonly ITestOutputHelper _logger;

		public DeckConstructorShouldShould(ITestOutputHelper logger)
		{
			_logger = logger;
		}

		[Fact]
		public void ShouldShuffleUponCreation()
		{
			var deckFactory = new FullDeckFactory();
			var deck1 = deckFactory.GetDeck();
			var deck2 = deckFactory.GetDeck();
			
			_logger.WriteLine($"\t\tCard\t\t\t\t\t\tDeck1\tDeck2");

			Assert.All(
				deck1.Cards.ToList(),
				card =>
				{
					var positionDeck1 = deck1.Cards.ToList().FindIndex(0, cd => Equals(cd, card));

					var positionDeck2 = deck2.Cards.ToList().FindIndex(0, cd => Equals(cd, card));

			   _logger.WriteLine($"{card}:   \t\t\t{positionDeck1}\t\t{positionDeck2}");

					Assert.NotEqual(positionDeck1, positionDeck2);
				});

			Assert.NotEqual(deck1, deck2);
		}

		[Fact]
		public void SuitsShouldBeEqual()
		{
			var diamond1 = Suit.Diamond;
			var diamond2 = Suit.Diamond;

			Assert.StrictEqual(diamond1, diamond2);
		}
	}
}