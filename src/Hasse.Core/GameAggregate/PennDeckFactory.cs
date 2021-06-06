using Shared.CardGame;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public class PennDeckFactory<T> : DeckFactory
		where T : CardGame
	{
		protected override Deck CreateDeck()
		{
			return GameType.FromName(typeof(T).Name).Deck;
		}
	}
}