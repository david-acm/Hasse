namespace Hasse.Core.DeckAggregate
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