using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;

namespace Shared.CardGame.DeckAggregate
{
    public class FullDeck : Deck
    {
        public FullDeck() 
	        : base(GetSuits(), GetRanks())
        {
        }

        private static List<Rank> GetRanks() => Rank.List.ToList();

        private static List<Suit> GetSuits() => Suit.List.ToList();

        public override IPrototype DeepCopy()
        {
            return new FullDeck();
        }

        public override Deck TryReBuildDeck(ICollection<Card> cards)
        {
	        Guard.Against.InvalidInput(cards,
		        nameof(cards),
		        c => c.Count == GetRanks().Count * GetSuits().Count);

	        cards.ForEach(c => Cards.Push(c));

	        return this;
        }
    }
}