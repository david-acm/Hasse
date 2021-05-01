using System.Linq;
using Hasse.Core.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
    public class Negative5Game : TwoPlayerCardGame
    {
        private static readonly DeckFactory DeckFactory = new FullDeckFactory();

        public Negative5Game(Team team1, Team team2) : base(team1, team2, DeckFactory)
        {
        }

        public override IPrototype DeepCopy()
        {
            var team1 = (Team)_teams.ElementAt(0)?.DeepCopy();
            var team2 = (Team)_teams.ElementAt(1)?.DeepCopy();

            return new Negative5Game(team1, team2);
        }
    }
}