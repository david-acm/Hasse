using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hasse.Core.DeckAggregate;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate
{
    public class HasseGame : TwoTeamsCardGame
    {
        private static readonly DeckFactory DeckFactory = new HasseDeckFactory();

        internal HasseGame(Team.Team team1, Team.Team team2)
            : base(team1, team2, DeckFactory)
        {
        }

        public override IPrototype DeepCopy()
        {
            var team1 = (Team.Team) _teams.ElementAt(0)?.DeepCopy();
            var team2 = (Team.Team) _teams.ElementAt(1)?.DeepCopy();

            return new HasseGame(team1, team2);
        }
    }
}