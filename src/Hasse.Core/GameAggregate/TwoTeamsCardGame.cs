using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.Core.DeckAggregate;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate
{
    public abstract class TwoTeamsCardGame : CardGame, IPrototype
    {
        private readonly Queue<Player.Player> _dealQueue;

        protected TwoTeamsCardGame(Team.Team team1, Team.Team team2, DeckFactory deckFactory)
            : base(deckFactory)
        {
            Guard.Against.Null(team1, nameof(team1));
            Guard.Against.Null(team2, nameof(team2));

            _teams = new List<Team.Team> { team1, team2 };

            _dealQueue = new Queue<Player.Player>(Players);
        }

        public IReadOnlyCollection<Team.Team> Teams => _teams.AsReadOnly();

        public virtual IPrototype ShallowCopy()
        {
            return (IPrototype)MemberwiseClone();
        }

        public abstract IPrototype DeepCopy();

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
    }
}