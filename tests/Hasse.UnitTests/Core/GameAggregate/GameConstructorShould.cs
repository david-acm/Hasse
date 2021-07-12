using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;
using Shared.TwoTeamsCardGame;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.GameAggregate
{
	public class GameConstructorShould
	{
		private readonly Game _game;
		private readonly ITestOutputHelper _logger;

		public GameConstructorShould(ITestOutputHelper logger)
		{
			_logger = logger;

			_game = new HappyPathGameBuilder();
		}

		[Fact]
		public void HaveADeckWith24Cards()
		{
			// Prepare

			// Execute

			// Assert
			var cardList = _game.Deck.Cards.ToList();
			cardList.ForEach(card => _logger.WriteLine($"{card.Suit.Symbol} {card.Name}"));

			Assert.Equal(24, cardList.Count);
		}

		[Fact]
		public void HaveADeckWithThe4Suits()
		{
			// Prepare

			// Execute

			// Assert
			var suitList = _game.Deck.Suits;
			suitList.ForEach(s => _logger.WriteLine($"{s.PluralizeName()} {s.Symbol}"));

			Assert.Equal(4, suitList.Count());
		}

		[Fact]
		public void HaveADeckWithThe6Ranks()
		{
			// Prepare

			// Execute

			// Assert
			IEnumerable<Rank> rankList = _game.Deck.Ranks;

			rankList.ForEach(s => _logger.WriteLine(s.NormalizeName()));

			Assert.Equal(6, rankList.Count());
		}

		[Fact]
		public void HaveTwoTeams()
		{
			// Prepare

			// Execute

			// Assert
			var teamCount = _game.Teams.Count;

			Assert.Equal(2, teamCount);
		}

		[Fact]
		public void ShallowCopyAll()
		{
			var game = (Game) _game.ShallowCopy();

			Assert.Same(game.Deck, _game.Deck);
			Assert.NotSame(game.Teams, _game.Teams);
		}

		[Fact]
		public void DeepCopyAll()
		{
			var game = (Game) _game.DeepCopy();

			Assert.NotSame(game.Teams, _game.Teams);
			Assert.NotSame(game.Deck, _game.Deck);
		}

		[Theory]
		[InlineData(HappyPathGameBuilder.David)]
		[InlineData(HappyPathGameBuilder.Allison)]
		[InlineData(HappyPathGameBuilder.Greta)]
		[InlineData(HappyPathGameBuilder.Joe)]
		public void HaveAssignedNames(string name)
		{
			_game.Teams.ToList().ForEach(t => Assert.NotNull(t.Name));

			var names = _game.Teams.SelectMany(t => t.Players.Select(p => p.Name));

			Assert.Contains(names, p => p == name);
		}

		[Fact]
		public void HavePlayersAssignedToGame()
		{
			Assert.All(_game.Players, 
				p =>
				{
					_logger.WriteLine(((Game)p.CurrentGame).ToString());
					Assert.Equal(p.CurrentGame, _game);
				});
		}

		[Fact]
		public void HaveCurrentHandWithOrderedTurnsQueue()
		{
			// Arrange
			var turnsCount = _game.CurrentHand.Turns.Count;
			var playerToTheLeftOfDealer = _game.Players.ElementAt(1);
			var playerWithFirstTurn = _game.CurrentHand.Turns.First().Player;
			var dealer = _game.Players.First(
				p => p.Position == DiagonalTeamPlayer.TablePosition.One);
			var playerWithTurnFour = _game.CurrentHand.Turns.ElementAt(3).Player;

			// Assert
			Assert.Equal(4, turnsCount);
			Assert.Equal(playerToTheLeftOfDealer, playerWithFirstTurn);
			Assert.Equal(dealer, playerWithTurnFour);
		}
	}
}