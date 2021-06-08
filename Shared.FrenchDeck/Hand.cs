using System.Collections.Generic;
using System.Linq;
using Shared.CardGame.DeckAggregate;
using Shared.CardGame.Player;

namespace Shared.CardGame
{
	public abstract class Hand
	{
		protected readonly Queue<Turn> _turns = new();
		protected IPlayer _dealer;
		protected CardGame _game;
		public IReadOnlyList<Turn> Turns => _turns.ToList().AsReadOnly();

		protected Hand(CardGame game, IPlayer dealer)
		{
			_game = game;
			_dealer = dealer;

			BuildTurnsQueue();
		}

		private IPlayer GetDealer()
		{
			return _game.Players.First();
		}

		protected void BuildTurnsQueue()
		{
			AddPlayersToTurnsQueue();
			do
			{
				RotateQueue();
			} while (DealerIsNotFirst());
		}

		private void AddPlayersToTurnsQueue()
		{
			_game.Players
				.ForEach(p => _turns.Enqueue(new Turn(p)));
		}

		private bool DealerIsNotFirst()
		{
			return _dealer != _turns.Peek().Player;
		}

		protected void RotateQueue()
		{
			var bid = _turns.Dequeue();
			_turns.Enqueue(bid);
		}
	}
}