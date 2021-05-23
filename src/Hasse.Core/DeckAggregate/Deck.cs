using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;

namespace Hasse.Core.DeckAggregate
{
	// Separate DeckAggregate into different project
	public abstract class Deck : BaseGameEntity
	{
		private static readonly Random Rng = new();
		private readonly IEnumerable<Rank> _ranks;
		private readonly IEnumerable<Suit> _suits;

		protected Deck(IEnumerable<Suit> suits, IEnumerable<Rank> ranks)
		{
			_suits = suits;
			_ranks = ranks;
			AddCards();
			Shuffle();
		}

		public Stack<Card> Cards { get; private set; } = new();

		public IReadOnlyCollection<Suit> Suits => Cards.Select(c => c.Suit).Distinct().ToList().AsReadOnly();

		public IReadOnlyCollection<Rank> Ranks => Cards.Select(c => c.Rank).Distinct().ToList().AsReadOnly();

		public int OriginalCardCount => _ranks.Count() * _suits.Count();

		public int CurrentCardCount => Cards.Count;

	  // TODO: Change try catch logic
		public virtual Deck TryReBuildDeck(ICollection<Card> cards)
		{
			try
			{
				Guard.Against.InvalidInput(cards,
					nameof(cards),
					c => c.Count == OriginalCardCount);

				cards.ForEach(c => Cards.Push(c));

				return this;
			}
			catch (ArgumentException e)
			{
				return this;
			}
		}

		private void AddCards()
		{
			_suits.ForEach(suit =>
				_ranks.ForEach(rank =>
					Cards.Push(new Card(suit, rank))));
		}
		
	  // TODO: Change visibility
		protected void Shuffle()
		{
			var n = Cards.Count;
			var cardList = Cards.ToArray();
			while (n > 1)
			{
				n--;
				var k = Rng.Next(n + 1);
				var value = cardList[k];
				cardList[k] = cardList[n];
				cardList[n] = value;
			}

			Cards = new Stack<Card>(cardList);
		}
	}
}