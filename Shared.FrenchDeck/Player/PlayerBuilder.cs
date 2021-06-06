using Hasse.SharedKernel;

namespace Shared.CardGame.Player
{
	public class PlayerBuilder : LazyBuilder<Player, PlayerBuilder>, IPlayerBuilder
	{
		private string _name;

		public IPlayerBuilder WithName(string name)
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