namespace Hasse.Core.GameAggregate
{
    public interface IPrototype
    {
        public IPrototype ShallowCopy();
        public IPrototype DeepCopy();
    }
}