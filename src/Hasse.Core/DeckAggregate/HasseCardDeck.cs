using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate;

namespace Hasse.Core.DeckAggregate
{
    public class HasseCardDeck : Deck
    {
        internal HasseCardDeck() : base(GetSuits(), GetRanks())
        {
            
        } 

        private static List<Rank> GetRanks() => Rank.List.Where(r => r >= Rank.Nine).ToList();

        private static List<Suit> GetSuits() => Suit.List.ToList();

        public override IPrototype DeepCopy() => new HasseCardDeck();
    }
}