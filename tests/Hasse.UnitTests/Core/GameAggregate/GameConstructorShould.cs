using System.Collections.Generic;
using System.Linq;
using Hasse.Core.DeckAggregate;
using Hasse.Core.GameAggregate;
using Hasse.SharedKernel;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class GameConstructorShould
	{
		private const string Player1Name = "David";
		private const string Player2Name = "Allison";
		private const string Player3Name = "Greta";
		private const string Player4Name = "Joe";
		private readonly HasseGame _hasseGame;
		private readonly ITestOutputHelper _logger;

		public GameConstructorShould(ITestOutputHelper logger)
		{
			_logger = logger;

			_hasseGame = new HappyPathGameBuilder();
		}

		[Fact]
		public void HaveADeckWith24Cards()
		{
			// Prepare

			// Execute

			// Assert
			var cardList = _hasseGame.Deck.Cards.ToList();
			cardList.ForEach(card => _logger.WriteLine($"{card.Suit.Symbol} {card.Name}"));

			Assert.Equal(24, cardList.Count);
		}

		[Fact]
		public void HaveADeckWithThe4Suits()
		{
			// Prepare

			// Execute

			// Assert
			var suitList = _hasseGame.Deck.Suits;
			suitList.ForEach(s => _logger.WriteLine($"{s.PluralizeName()} {s.Symbol}"));

			Assert.Equal(4, suitList.Count());
		}

		[Fact]
		public void HaveADeckWithThe6Ranks()
		{
			// Prepare

			// Execute

			// Assert
			IEnumerable<Rank> rankList = _hasseGame.Deck.Ranks;

			rankList.ForEach(s => _logger.WriteLine(s.NormalizeName()));

			Assert.Equal(6, rankList.Count());
		}

		[Fact]
		public void HaveTwoTeams()
		{
			// Prepare

			// Execute

			// Assert
			var teamCount = _hasseGame.Teams.Count;

			Assert.Equal(2, teamCount);
		}

		[Fact]
		public void ShallowCopyAll()
		{
			var game = (HasseGame) _hasseGame.ShallowCopy();

			Assert.Same(game.Deck, _hasseGame.Deck);
			Assert.NotSame(game.Teams, _hasseGame.Teams);
		}

		[Fact]
		public void DeepCopyAll()
		{
			var game = (HasseGame) _hasseGame.DeepCopy();

			Assert.NotSame(game.Teams, _hasseGame.Teams);
			Assert.NotSame(game.Deck, _hasseGame.Deck);
		}

		[Theory]
		[InlineData(Player1Name)]
		[InlineData(Player2Name)]
		[InlineData(Player3Name)]
		[InlineData(Player4Name)]
		public void ShouldHaveAssignedNames(string name)
		{
			_hasseGame.Teams.ToList().ForEach(t => Assert.NotNull(t.Name));

			var names = _hasseGame.Teams.SelectMany(t => t.Players.Select(p => p.Name));

			Assert.Contains(names, p => p == name);
		}

		[Fact]
		public void SamePositionDifferentDeckShouldNotBeEqual()
		{
			var deckFactory = new HasseDeckFactory();
			var deck1 = deckFactory.GetDeck();
			var deck2 = deckFactory.GetDeck();

			Assert.NotEqual(deck1, deck2);
			Assert.NotEqual(
				deck1.Cards.FirstOrDefault(),
				deck2.Cards.FirstOrDefault());
		}

		[Fact]
		public void SuitsShouldBeEqual()
		{
			var diamond1 = Suit.Diamond;
			var diamond2 = Suit.Diamond;

			Assert.StrictEqual(diamond1, diamond2);
		}

		[Fact]
		public void ShouldShuffleUponConstruction()
		{
			var gameCards = _hasseGame.Deck.Cards;

			var sorted = gameCards.OrderBy(c => c.Rank).ToList();

			gameCards.ForEach(gc =>
				_logger.WriteLine($"{gc.Suit.Symbol} {gc.Name}", gc.Suit.Color));

			Assert.NotEqual(sorted.First(), gameCards.First());
			Assert.NotEqual(sorted.Last(), gameCards.First());
		}

		[Fact]
		public void DealShouldGive6CardsToEachPlayer()
		{
			_hasseGame.Deal();
			_hasseGame.Deal();

			Assert.All(
				_hasseGame.Players,
				p => Assert.Equal(6, p.Hand.Count));
		}

		// TODO: Separate Tests by Aggregat/Method/Fact
		[Fact]
		public void DeckShouldBeEmptyAfterDeal()
		{
			_hasseGame.Deal();

			Assert.Empty(_hasseGame.Deck.Cards);
		}
	}
}