using System;
using System.Collections.Generic;
using System.Linq;

namespace Hasse.SharedKernel
{
    public abstract class LazyBuilder<TSubject, TSelf> : ILazyBuilder<TSubject>
        where TSelf : LazyBuilder<TSubject, TSelf>
    {
        private readonly List<Func<TSubject, TSubject>> actions = new();

        public virtual TSubject Build()
        {
            return actions.Aggregate(Construct(), (p, f) => f(p));
        }

        public TSelf Do(Action<TSubject> action)
        {
            return AddAction(action);
        }

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(b =>
            {
                action(b);
                return b;
            });

            return (TSelf)this;
        }

        protected abstract TSubject Construct();

        public static implicit operator TSubject(LazyBuilder<TSubject, TSelf> builder)
        {
            return builder.Build();
        }
    }
}