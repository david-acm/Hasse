using Ardalis.SmartEnum;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public abstract class GameType : SmartEnum<GameType>
	{
		public static readonly GameType Hasse = new HasseType();
		public static readonly GameType Negative5 = new Negative5Type();

		protected GameType(string name, int value)
			: base(name, value)
		{
		}

		public abstract Deck Deck { get; }

		private sealed class HasseType : GameType
		{
			public HasseType() : base(nameof(HasseGame), 1)
			{
			}

			public override Deck Deck => new HasseCardDeck();
		}

		private sealed class Negative5Type : GameType
		{
			public Negative5Type() : base(nameof(Negative5Game), 2)
			{
			}

			public override Deck Deck => new FullDeck();
		}
	}
}