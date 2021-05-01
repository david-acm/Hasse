namespace Hasse.Core.DeckAggregate
{
    public class HasseDeckFactory : DeckFactory
    {
        protected override HasseCardDeck CreateDeck()
        {
            return new HasseCardDeck();
        }
    }
}