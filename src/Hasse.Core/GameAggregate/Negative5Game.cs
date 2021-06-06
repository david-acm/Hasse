using System.Linq;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Hasse.Core.GameAggregate
{
	public class Negative5Game : TwoTeamsCardGame
	{
		private static readonly DeckFactory DeckFactory = new PennDeckFactory<Negative5Game>();

		public Negative5Game(Team.Team team1, Team.Team team2) : base(team1, team2, DeckFactory)
		{
		}

		public override IPrototype DeepCopy()
		{
			var team1 = (Team.Team) Teams.ElementAt(0)?.DeepCopy();
			var team2 = (Team.Team) Teams.ElementAt(1)?.DeepCopy();

			return new Negative5Game(team1, team2);
		}
	}
}