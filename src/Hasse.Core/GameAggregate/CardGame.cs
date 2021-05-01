using System.Collections.Generic;
using Hasse.Core.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public abstract class CardGame
    {
        protected CardGame(DeckFactory deckFactory)
        {
            Deck = deckFactory.GetDeck();
        }

        protected List<Team> _teams;
        public Deck Deck { get; }
    }
}