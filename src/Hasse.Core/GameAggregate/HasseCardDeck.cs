using System.Collections.Generic;
using System.Linq;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public class HasseCardDeck : Deck
    {
        internal HasseCardDeck() : this(GetSuits(), GetRanks())
        {
        }

        private HasseCardDeck(IEnumerable<Suit> suits, IEnumerable<Rank> ranks) : base(suits, ranks)
        {
        }
        private static List<Rank> GetRanks()
        {
            return Rank.List.Where(r => r >= Rank.Nine).ToList();
        }

        private static List<Suit> GetSuits()
        {
            return Suit.List.ToList();
        }

        public override IPrototype DeepCopy()
        {
            return new HasseCardDeck(Suits, Ranks);
        }
    }
}