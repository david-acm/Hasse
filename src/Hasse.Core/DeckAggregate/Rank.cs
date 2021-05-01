using Ardalis.SmartEnum;

namespace Hasse.Core.DeckAggregate
{
    public abstract class Rank : SmartEnum<Rank>
    {
        public static readonly Rank One = new OneType();
        public static readonly Rank Two = new TwoType();
        public static readonly Rank Three= new ThreeType();
        public static readonly Rank Four = new FourType();
        public static readonly Rank Five = new FiveType();
        public static readonly Rank Six = new SixType();
        public static readonly Rank Seven= new SevenType();
        public static readonly Rank Eight = new EightType();
        public static readonly Rank Nine = new NineType();
        public static readonly Rank Ten = new TenType();
        public static readonly Rank Jack = new JackType();
        public static readonly Rank Queen = new QueenType();
        public static readonly Rank King = new KingType();
        public static readonly Rank Ace = new AceType();

        private Rank(string name, int value) : base(name, value) {}

        public abstract string Symbol { get; }

        private sealed class OneType : Rank
        {
            public OneType() : base(nameof(OneType), 1) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class TwoType : Rank
        {
            public TwoType() : base(nameof(TwoType), 2) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class ThreeType : Rank
        {
            public ThreeType() : base(nameof(ThreeType), 3) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class FourType : Rank
        {
            public FourType() : base(nameof(FourType), 4) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class FiveType : Rank
        {
            public FiveType() : base(nameof(FiveType), 5) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class SixType : Rank
        {
            public SixType() : base(nameof(SixType), 6) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class SevenType : Rank
        {
            public SevenType() : base(nameof(SevenType), 7) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class EightType : Rank
        {
            public EightType() : base(nameof(EightType), 8) { }
            public override string Symbol => this.Value.ToString();
        }
        private sealed class NineType : Rank
        {
            public NineType() : base(nameof(NineType), 9) { }
            public override string Symbol => this.Value.ToString();
        }

        private sealed class TenType : Rank
        {
            public TenType() : base(nameof(TenType), 10) { }
            public override string Symbol => this.Value.ToString();
        }

        private sealed class JackType : Rank
        {
            public JackType() : base(nameof(JackType), 11) { }
            public override string Symbol => "J";
        }

        private sealed class QueenType : Rank
        {
            public QueenType() : base(nameof(QueenType), 12) { }
            public override string Symbol => "Q";
        }

        private sealed class KingType : Rank
        {
            public KingType() : base(nameof(KingType), 13) { }

            public override string Symbol => "K";
        }

        private sealed class AceType : Rank
        {
            public AceType() : base(nameof(AceType), 14) { }

            public override string Symbol => "A";
        }
    }
}