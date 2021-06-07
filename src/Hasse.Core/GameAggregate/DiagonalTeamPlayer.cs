using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
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

		protected internal DiagonalTeamPlayer(string name) : base(name)
		{
		}

		public TablePosition Position { get; internal set; }


		public override IPrototype DeepCopy()
		{
			return new DiagonalTeamPlayer(Name);
		}
	}
}