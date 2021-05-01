using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Hasse.Core.DeckAggregate;
using Hasse.Core.GameAggregate;
using Hasse.SharedKernel;
using Xunit;
using Xunit.Abstractions;

namespace Hasse.UnitTests.Core.GameAggregate
{
    public class GameConstructorShould
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private HasseGame _hasseGame;
        private Team _testTeam;

        public GameConstructorShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void HaveADeckWith24Cards()
        {
            // Prepare

            // Execute

            // Assert
            var cardList = _hasseGame.Deck.Cards.ToList();
            cardList.ForEach(card => _testOutputHelper.WriteLine($"{card.Suit.Symbol} {card.Name}"));

            Assert.Equal(24, cardList.Count); 
        }

        [Fact]
        public void HaveADeckWithThe4Suits()
        {
            // Prepare

            // Execute

            // Assert
            var suitList = _hasseGame.Deck.Cards
                .GroupBy(c => c.Suit)
                .Select(x => x.Key)
                .ToList();
            suitList.ToList().ForEach(s => _testOutputHelper.WriteLine($"{s.PluralizeName()} {s.Symbol}"));

            Assert.Equal(4, suitList.Count());
        }

        [Fact]
        public void HaveADeckWithThe6Ranks()
        {
            // Prepare

            // Execute

            // Assert
            IEnumerable<Rank> rankList = _hasseGame.Deck.Cards
                .GroupBy(c => c.Rank)
                .Select(x => x.Key)
                .OrderBy(r => r.Value).ToList();
            rankList.ToList().ForEach(s => _testOutputHelper.WriteLine(s.NormalizeName()));

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
            var game = (HasseGame)_hasseGame.ShallowCopy(); 

            Assert.Same(game.Deck, _hasseGame.Deck);
            Assert.NotSame(game.Teams, _hasseGame.Teams);
        }

        [Fact]
        public void DeepCopyAll()
        {
            var game = (HasseGame)_hasseGame.DeepCopy();

            Assert.NotSame(game.Teams, _hasseGame.Teams);
            Assert.NotSame(game.Deck, _hasseGame.Deck);
        }
    }
}