using System;

namespace Shared.CardGame.Player
{
	public class PlayerBuilder : BasePlayerBuilder<Player>
	{
		private string _name;

		protected override Type playerType => typeof(Player);

		public override PlayerBuilder WithName(string name)
		{
			_name = name;
			return this;
		}

		protected override Player Construct()
		{
			return new(_name);
		}
	}
}