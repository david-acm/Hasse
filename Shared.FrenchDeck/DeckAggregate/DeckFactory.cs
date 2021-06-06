namespace Shared.CardGame.DeckAggregate
{
    public abstract class DeckFactory
    {
        protected abstract Deck CreateDeck();

        public Deck GetDeck()
        {
            return CreateDeck();
        }
    }
}