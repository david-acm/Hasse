using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Builders
{
	public class HassePlayerBuilder : BasePlayerBuilder<DiagonalTeamPlayer>
	{
		private string _name;

		public override HassePlayerBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		public HassePlayerBuilder WithPosition(DiagonalTeamPlayer.TablePosition position)
		{
			Do(p => p.Position = position);
			return this;
		}

		protected override DiagonalTeamPlayer Construct()
		{
			return new(_name);
		}
	}
}