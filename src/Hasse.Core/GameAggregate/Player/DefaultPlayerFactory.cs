namespace Hasse.Core.GameAggregate.Player
{
    public class DefaultPlayerFactory : PlayerFactory
    {
        protected override Player CreatePlayer(string name)
        {
            return new(name);
        }
    }
}