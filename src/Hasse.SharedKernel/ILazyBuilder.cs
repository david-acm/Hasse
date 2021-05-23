namespace Hasse.SharedKernel
{
    public interface ILazyBuilder<TSubject>
    {
        public TSubject Build();
    }
}