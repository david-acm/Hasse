namespace Hasse.Core.DeckAggregate
{
    public class FullDeckFactory : DeckFactory
    {
        protected override FullDeck CreateDeck()
        {
            return new FullDeck();
        }
    }
}