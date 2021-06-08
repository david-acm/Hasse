using Ardalis.SmartEnum;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public abstract class Variation : SmartEnum<Variation>
	{
		public static readonly Variation Default = new DefaultType();

		protected Variation(string name, int value)
			: base(name, value)
		{
		}

		public abstract Shared.CardGame.DeckAggregate.Deck Deck { get; }

		private sealed class DefaultType : Variation
		{
			public DefaultType() : base(nameof(Game), 1)
			{
			}

			public override Shared.CardGame.DeckAggregate.Deck Deck => new Deck();
		}
	}
}