using Hasse.Core.GameAggregate.Team;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
{
	public class DiagonalTeamPlayer : Player, IPlayer
	{
		public enum TablePosition
		{
			One,
			Two,
			Three,
			Four
		}

		protected internal DiagonalTeamPlayer(string name) : base(name)
		{
		}

		public TablePosition Position { get; internal set; }
	}
}