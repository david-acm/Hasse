using System.Drawing;
using Ardalis.SmartEnum;

namespace Shared.CardGame.DeckAggregate
{
    public abstract class Suit : SmartEnum<Suit>
    {
        public static readonly Suit Heart = new HeartType();
        public static readonly Suit Club = new ClubType();
        public static readonly Suit Spade = new SpadeType();
        public static readonly Suit Diamond = new DiamondType();

        private Suit(string name, int value) : base(name, value)
        {
        }

        public abstract Color Color { get; }
        public abstract char Symbol { get; }

        private sealed class HeartType : Suit
        {
            public HeartType() : base(nameof(HeartType), 1)
            {
            }

            public override Color Color => Color.Red;
            public override char Symbol => '❤';
        }

        private sealed class DiamondType : Suit
        {
            public DiamondType() : base(nameof(DiamondType), 2)
            {
            }

            public override Color Color => Color.Red;
            public override char Symbol => '♦';
        }

        private sealed class SpadeType : Suit
        {
            public SpadeType() : base(nameof(SpadeType), 3)
            {
            }

            public override Color Color => Color.Black;
            public override char Symbol => '♠';
        }

        private sealed class ClubType : Suit
        {
            public ClubType() : base(nameof(ClubType), 4)
            {
            }

            public override Color Color => Color.Black;
            public override char Symbol => '♣';
        }
    }
}