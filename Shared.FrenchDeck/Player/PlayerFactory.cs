using Ardalis.GuardClauses;

namespace Shared.CardGame.Player
{
    public abstract class PlayerFactory
    {
        protected abstract Player CreatePlayer(string name);

        public Player GetPlayer(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            return CreatePlayer(name);
        }
    }
}