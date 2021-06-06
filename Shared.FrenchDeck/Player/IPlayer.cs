using System.Collections.Generic;
using Hasse.SharedKernel;
using Shared.CardGame.DeckAggregate;

namespace Shared.CardGame.Player
{
	public interface IPlayer : IPrototype
	{
		string Name { get; }
		List<Card> Hand { get; }
		CardGame CurrentGame { get; set; }
	}
}