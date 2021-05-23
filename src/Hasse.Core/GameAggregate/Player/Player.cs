using System.Collections.Generic;
using Ardalis.GuardClauses;
using Hasse.Core.DeckAggregate;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate.Player
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
        public List<Card> Hand { get; } = new();

        public IPrototype ShallowCopy()
        {
            return (IPrototype) MemberwiseClone();
        }

        public IPrototype DeepCopy()
        {
            return new Player(Name);
        }

        public void ClearHand()
        {
           Hand.Clear();
        }

        // Option 1: Static factory method
        public static Player New(string name)
        {
            return new(name);
        }

        // Option 2: Inner factory
        public static class Factory
        {
            public static Player CreatePlayer(string name)
            {
                return new(name);
            }
        }
    }
}