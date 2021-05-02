using Ardalis.GuardClauses;

namespace Hasse.Core.GameAggregate
{
    public class Player : IPrototype
    {
        internal Player(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        public string Name { get; }
        public int Score { get; }

        public IPrototype ShallowCopy()
        {
            return (IPrototype) this.MemberwiseClone();
        }

        public IPrototype DeepCopy()
        {
            return new Player(this.Name);
        }
        
        // Option 1: Static factory method
        public static Player New(string name) => new(name);

        // Option 2: Inner factory
        public static class Factory
        {
            public static Player CreatePlayer(string name) => new(name);
        }
    }
}