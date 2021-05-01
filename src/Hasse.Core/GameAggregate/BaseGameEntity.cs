using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate
{
    public abstract class BaseGameEntity : BaseEntity, IPrototype
    {
        public virtual IPrototype ShallowCopy()
        {
            return (IPrototype)this.MemberwiseClone();
        }

        public abstract IPrototype DeepCopy();
    }
}