using System.Linq;
using Hasse.Core.DeckAggregate;
using Microsoft.VisualBasic;

namespace Hasse.Core.GameAggregate
{
    public class HasseGame : TwoPlayerCardGame
    {
        private static readonly DeckFactory DeckFactory = new HasseDeckFactory();

        internal HasseGame(Team team1, Team team2) 
            : base(team1, team2, DeckFactory)
        {
        }

        public override IPrototype DeepCopy()
        {
            var team1 = (Team)_teams.ElementAt(0)?.DeepCopy();
            var team2 = (Team)_teams.ElementAt(1)?.DeepCopy();

            return new HasseGame(team1, team2);
        }
    }
}