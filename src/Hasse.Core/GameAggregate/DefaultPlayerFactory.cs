namespace Hasse.Core.GameAggregate
{
    public class DefaultPlayerFactory : PlayerFactory
    {
        protected override Player CreatePlayer(string name) => new(name);
    }
}