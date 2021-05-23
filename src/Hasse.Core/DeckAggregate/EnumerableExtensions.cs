using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace Hasse.Core.DeckAggregate
{
	public static class EnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			Guard.Against.Null(enumerable, nameof(enumerable));

			enumerable.ToList().ForEach(action);
		}
	}
}