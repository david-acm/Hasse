namespace Hasse.SharedKernel
{
    public abstract class BaseGameEntity : BaseEntity, IPrototype
    {
        public virtual IPrototype ShallowCopy()
        {
            return (IPrototype) MemberwiseClone();
        }

        public abstract IPrototype DeepCopy();
    }
}