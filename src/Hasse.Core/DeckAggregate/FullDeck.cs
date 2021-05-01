using System.Linq;
using Hasse.Core.GameAggregate;

namespace Hasse.Core.DeckAggregate
{
    public class FullDeck : Deck
    {
        public FullDeck() : base(Suit.List.ToList(), Rank.List.ToList())
        {
        }

        public override IPrototype DeepCopy()
        {
            return new FullDeck();
        }
    }
}