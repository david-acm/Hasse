using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Shared.TwoTeamsCardGame
{
	public class DiagonalTeamPlayer : Player
	{
		public enum TablePosition
		{
			One,
			Two,
			Three,
			Four
		}

		public DiagonalTeamPlayer(string name) : base(name)
		{
		}

		public TablePosition Position { get; set; }


		public override IPrototype DeepCopy()
		{
			return new DiagonalTeamPlayer(Name);
		}
	}
}