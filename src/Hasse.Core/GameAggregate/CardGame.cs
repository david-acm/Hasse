using System.Collections.Generic;
using System.Linq;
using Hasse.Core.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public abstract class CardGame
    {
        protected List<Team.Team> _teams;

        protected CardGame(DeckFactory deckFactory)
        {
            Deck = deckFactory.GetDeck();
        }

        public Deck Deck { get; }

        public IEnumerable<Player.Player> Players =>
	        _teams.SelectMany(t => t.Players);
    }
}