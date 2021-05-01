using System;
using System.Collections.Generic;
using System.Linq;

namespace Hasse.Core.GameAggregate
{
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
    private readonly List<Func<TSubject, TSubject>> actions = new();

    public TSelf Do(Action<TSubject> action) => AddAction(action);

    private TSelf AddAction(Action<TSubject> action)
    {
        actions.Add(b =>
        {
            action(b);
            return b;
        });

        return (TSelf) this;
    }

    public virtual TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));
    }
}