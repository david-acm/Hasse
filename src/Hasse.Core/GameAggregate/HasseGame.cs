using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
{
	public class HasseGame : TwoTeamsCardGame
	{
		private static readonly DeckFactory DeckFactory = new PennDeckFactory<HasseGame>();
		private readonly List<Hand> _hands = new();
		private readonly IPlayer _dealer;

		internal HasseGame(Team.Team team1, Team.Team team2, IPlayer dealer)
			: base(team1, team2, DeckFactory)
		{
			Players.ForEach(p => p.CurrentGame = this);
			_dealer = dealer;
			CurrentHand = new Hand(this, dealer);
			_hands.Add(CurrentHand);
		}

		internal HasseGame(Team.Team team1, Team.Team team2)
			: base(team1, team2, DeckFactory)
		{
			Players.ForEach(p => p.CurrentGame = this);
			CurrentHand = new Hand(this, Players.First());
			_hands.Add(CurrentHand);
		}

		/// <summary>
		/// Gets the current hand being played.
		/// </summary>
		public Hand CurrentHand { get; }

		/// <summary>
		/// Gets all the players of the game.
		/// </summary>
		public new IEnumerable<DiagonalTeamPlayer> Players => Teams.SelectMany(t => t.Players).Select(p => (DiagonalTeamPlayer)p);

		public override IPrototype DeepCopy()
		{
			var team1 = (Team.Team) Teams.ElementAt(0)?.DeepCopy();
			var team2 = (Team.Team) Teams.ElementAt(1)?.DeepCopy();

			return new HasseGame(team1, team2);
		}

		public HasseGame Bid(Bid bid)
		{
			CurrentHand.Bid(bid);
			return this;
		}
	}
}