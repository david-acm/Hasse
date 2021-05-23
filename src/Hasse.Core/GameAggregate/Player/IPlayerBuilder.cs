using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate.Player
{
    public interface IPlayerBuilder : ILazyBuilder<Player>
    {
        IPlayerBuilder WithName(string name);
    }
}