using Hasse.SharedKernel;

namespace Shared.CardGame.Player
{
    public interface IPlayerBuilder : ILazyBuilder<Player>
    {
        IPlayerBuilder WithName(string name);
    }
}