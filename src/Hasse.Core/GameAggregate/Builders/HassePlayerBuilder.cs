using System;
using Shared.CardGame.Player;
using Shared.TwoTeamsCardGame;

namespace Hasse.Core.GameAggregate.Builders
{
	public class HassePlayerBuilder : BasePlayerBuilder<DiagonalTeamPlayer>
	{
		private string _name;

		protected override Type playerType => typeof(DiagonalTeamPlayer);

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