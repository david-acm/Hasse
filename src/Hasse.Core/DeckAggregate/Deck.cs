using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate;

namespace Hasse.Core.DeckAggregate
{
    public abstract class Deck : BaseGameEntity
    {
        private readonly ICollection<Suit> _suits;
        private readonly ICollection<Rank> _ranks;

        protected Deck(ICollection<Suit> suits, ICollection<Rank> ranks)
        {
            _suits = suits;
            _ranks = ranks;
            _suits.ToList().ForEach(AddSuitCards);
        }

        private void AddSuitCards(Suit suit)
        {
            _ranks.ToList().ForEach(r => _cards.Add(new Card(suit, r)));
        }

        private readonly List<Card> _cards = new();
        public IEnumerable<Card> Cards => _cards;
    }
}