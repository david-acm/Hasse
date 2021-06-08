using System.Collections.Generic;
using System.Linq;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public class Deck : Shared.CardGame.DeckAggregate.Deck
    {
        internal Deck() : this(GetSuits(), GetRanks())
        {
        }

        private Deck(IEnumerable<Suit> suits, IEnumerable<Rank> ranks) : base(suits, ranks)
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
            return new Deck(Suits, Ranks);
        }
    }
}