namespace Shared.CardGame.DeckAggregate
{
    public sealed class FullDeckFactory : DeckFactory
    {
        protected override FullDeck CreateDeck()
        {
            return new();
        }
    }
}