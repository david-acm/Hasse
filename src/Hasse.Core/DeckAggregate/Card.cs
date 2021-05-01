using Ardalis.GuardClauses;
using Hasse.Core.GameAggregate;
using Hasse.SharedKernel;

namespace Hasse.Core.DeckAggregate
{
    public class Card : BaseGameEntity
    {
        internal Card(Suit suit, Rank rank)
        {
            Guard.Against.Null(suit, nameof(suit));
            Guard.Against.Null(rank, nameof(rank));

            this.Suit = suit;
            this.Rank = rank;
        }

        public Suit Suit { get; }
        public Rank Rank { get; }
        public string Name => $"{Rank.NormalizeName()} of {Suit.NormalizeName()}s";

        public override IPrototype DeepCopy()
        {
            return (IPrototype) new Card(this.Suit, this.Rank);
        }
    }
}