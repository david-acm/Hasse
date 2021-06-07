using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Shared.CardGame.Player
{
	public class Player : IPlayer
	{
		protected internal Player(string name)
		{
			Guard.Against.NullOrWhiteSpace(name, nameof(name));

			Name = name;
		}

		public string Name { get; }
		public int Score { get; }
		public List<Card> Hand { get; } = new();
		public CardGame CurrentGame { get; set; }

		public IPrototype ShallowCopy()
		{
			return (IPrototype) MemberwiseClone();
		}

		public virtual IPrototype DeepCopy()
		{
			return new Player(Name);
		}

		public void ClearHand()
		{
			Hand.Clear();
		}

		public override string ToString() => Name;
	}
}