using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.CardGame.DeckAggregate;
using Shared.CardGame.Player;

namespace Shared.CardGame
{
	public abstract class CardGame
	{
		protected readonly IEnumerable<IPlayer> _players;

		protected CardGame(DeckFactory deckFactory, IEnumerable<IPlayer> players)
		{
			Deck = deckFactory.GetDeck();
			_players = players;
		}

		public Deck Deck { get; }

		public virtual IReadOnlyList<IPlayer> Players =>
			_players.ToList().AsReadOnly();
	}
}