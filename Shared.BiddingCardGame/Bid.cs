using System;
using Shared.CardGame.Player;

namespace Shared.BiddingCardGame
{
	public class Bid : IEquatable<Bid>
	{
		public Bid(IPlayer player, Values value)
		{
			Player = player;
			Value = value;
		}

		public IPlayer Player { get; }
		public Values Value { get; private set; }

		public enum Values
		{
			One,
			Two,
			Three,
			Four,
			Five,
			Six,
			Hasse,
			DoubleHasse
		}

		public bool Equals(Bid other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(Player, other.Player) && Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (obj is null) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == this.GetType() && Equals((Bid) obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Player, (int) Value);
		}
	}
}