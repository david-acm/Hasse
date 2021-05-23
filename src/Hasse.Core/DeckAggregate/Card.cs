using System;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;

namespace Hasse.Core.DeckAggregate
{
    public class Card : BaseGameEntity, IEquatable<Card>
    {
        internal Card(Suit suit, Rank rank)
        {
            Guard.Against.Null(suit, nameof(suit));
            Guard.Against.Null(rank, nameof(rank));

            Suit = suit;
            Rank = rank;
        }

        public Suit Suit { get; }
        public Rank Rank { get; }
        public string Name => $"{Rank.NormalizeName()} of {Suit.NormalizeName()}s";

        public override IPrototype DeepCopy()
        {
            return new Card(Suit, Rank);
        }

        public bool Equals(Card other)
        {
	        if (other is null) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return Equals(Suit, other.Suit) && Equals(Rank, other.Rank);
        }

        public override bool Equals(object obj)
        {
	        if (obj is null) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        return obj.GetType() == this.GetType() && Equals((Card) obj);
        }

        public override int GetHashCode()
        {
	        return HashCode.Combine(Suit, Rank);
        }

        public override string ToString()
        {
	        return Name;
        }
    }
}