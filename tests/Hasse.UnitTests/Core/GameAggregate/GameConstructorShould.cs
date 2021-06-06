using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class GameConstructorShould
	{
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
		[InlineData(HappyPathGameBuilder.Player1Name)]
		[InlineData(HappyPathGameBuilder.Player2Name)]
		[InlineData(HappyPathGameBuilder.Player3Name)]
		[InlineData(HappyPathGameBuilder.Player4Name)]
		public void HaveAssignedNames(string name)
		{
			_hasseGame.Teams.ToList().ForEach(t => Assert.NotNull(t.Name));

			var names = _hasseGame.Teams.SelectMany(t => t.Players.Select(p => p.Name));

			Assert.Contains(names, p => p == name);
		}

		[Fact]
		public void HavePlayersAssignedToGame()
		{
			Assert.All(_hasseGame.Players, 
				p =>
				{
					_logger.WriteLine(((HasseGame)p.CurrentGame).ToString());
					Assert.Equal(p.CurrentGame, _hasseGame);
				});
		}
	}
}