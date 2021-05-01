using System.Collections.Generic;
using Ardalis.GuardClauses;
using Hasse.Core.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public abstract class TwoPlayerCardGame : CardGame, IPrototype
    {
        protected TwoPlayerCardGame(Team team1, Team team2, DeckFactory deckFactory)
        : base (deckFactory)
        {
            Guard.Against.Null(team1, nameof(team1));
            Guard.Against.Null(team2, nameof(team2));

            _teams = new List<Team> { team1, team2 };
        }

        public IReadOnlyCollection<Team> Teams => _teams.AsReadOnly();

        public virtual IPrototype ShallowCopy()
        {
            return (IPrototype)this.MemberwiseClone();
        }

        public abstract IPrototype DeepCopy();
    }
}