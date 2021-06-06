using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;
using Shared.CardGame;
using Shared.CardGame.DeckAggregate;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
	public abstract class TwoTeamsCardGame : CardGame, IPrototype
	{
		private readonly Queue<IPlayer> _dealQueue;
		private readonly List<Team> _teams;

		protected TwoTeamsCardGame(Team team1, Team team2, DeckFactory deckFactory)
			: base(deckFactory, GetPlayers(team1, team2))
		{
			Guard.Against.Null(team1, nameof(team1));
			Guard.Against.Null(team2, nameof(team2));

			_teams = new List<Team> {team1, team2};

			_dealQueue = new Queue<IPlayer>(Players);
		}

		public IReadOnlyList<Team> Teams => _teams.AsReadOnly();

		public virtual IPrototype ShallowCopy()
		{
			return (IPrototype) MemberwiseClone();
		}

		public virtual IPrototype DeepCopy()
		{
			var team1 = (Team) _teams.ElementAt(0)?.DeepCopy();
			var team2 = (Team) _teams.ElementAt(1)?.DeepCopy();

			return new Negative5Game(team1, team2);
		}

		private static IEnumerable<IPlayer> GetPlayers(Team team1, Team team2)
		{
			return team1.Players.Union(team2.Players);
		}

		// TODO: Review encapsulation of Game methods
		public virtual void Deal()
		{
			var gameCards = CollectCards();

			Deck.TryReBuildDeck(gameCards);

			do
			{
				_dealQueue.ToArray().ForEach(p =>
					p.Hand.Add(Deck.Cards.Pop()));
			} while (Deck.Cards.Count > 0);

			RotateDealQueue();
		}

		private List<Card> CollectCards()
		{
			return Players.SelectMany(p =>
			{
				var cards = p.Hand.Select(c => c).ToList();
				p.Hand.Clear();

				return cards;
			}).ToList();
		}

		private void RotateDealQueue()
		{
			var firstPlayer = _dealQueue.Dequeue();
			_dealQueue.Enqueue(firstPlayer);
		}

		public override string ToString()
		{
			return $"Game: '{Teams[0]}' vs '{Teams[1]}'";
		}
	}
}