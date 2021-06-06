namespace Shared.CardGame.Player
{
	public class PlayerBuilder : BasePlayerBuilder<Player>
	{
		private string _name;

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