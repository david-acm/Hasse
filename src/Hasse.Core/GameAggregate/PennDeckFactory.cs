using Shared.CardGame;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public class PennDeckFactory<T> : DeckFactory
		where T : CardGame
	{
		protected override Shared.CardGame.DeckAggregate.Deck CreateDeck()
		{
			return Variation.FromName(typeof(T).Name).Deck;
		}
	}
}