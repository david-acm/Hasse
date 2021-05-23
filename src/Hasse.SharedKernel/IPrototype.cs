namespace Hasse.SharedKernel
{
    public interface IPrototype
    {
        public IPrototype ShallowCopy();
        public IPrototype DeepCopy();
    }
}