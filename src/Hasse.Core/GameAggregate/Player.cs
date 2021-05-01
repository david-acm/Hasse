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

        public IPrototype ShallowCopy()
        {
            return (IPrototype) this.MemberwiseClone();
        }

        public IPrototype DeepCopy()
        {
            return new Player(this.Name);
        }
    }
}