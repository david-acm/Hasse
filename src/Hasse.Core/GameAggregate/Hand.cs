using System;
using System.Collections.Generic;
using System.Linq;
using Hasse.Core.GameAggregate.Exceptions;
using Shared.CardGame.DeckAggregate;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate
{
	public class Hand
	{
		private readonly Queue<Turn> _turns = new();
		private readonly List<Bid> _bids = new();
		private readonly IPlayer _dealer;
		private readonly HasseGame _game;

		internal Hand(HasseGame game, IPlayer dealer)
		{
			_game = game;
			_dealer = dealer;

			BuildTurnsQueue();
		}

		public void Bid(Bid bid)
		{
			// TODO: Change to guard clause
			ValidateBid(bid);

			_bids.Add(bid);

			RotateQueue();
		}

		public IReadOnlyList<Turn> Turns => _turns.ToList().AsReadOnly();
		public IReadOnlyList<Bid> Bids => _bids.ToList().AsReadOnly();

		private DiagonalTeamPlayer GetDealer()
		{
			return _game.Players.First();
		}

		private void BuildTurnsQueue()
		{
			AddPlayersToTurnsQueue();
			do
			{
				RotateQueue();
			} while (DealerIsNotFirst());
		}

		private void AddPlayersToTurnsQueue()
		{
			_game.Players.OrderBy(p => p.Position)
				.ForEach(p => _turns.Enqueue(new Turn(p)));
		}

		private bool DealerIsNotFirst()
		{
			return _dealer != _turns.Peek().Player;
		}

		private void RotateQueue()
		{
			var bid = _turns.Dequeue();
			_turns.Enqueue(bid);
		}

		private void ValidateBid(Bid bid)
		{
			try
			{
				var noBids = !Bids.Any();
				var underLastBids = Bids.Any(b => b.Value >= bid.Value);
				var notYourTurn = _turns.Peek().Player != bid.Player;

				if (noBids) return;
				if (underLastBids) throw new BidUnderPermittedException();
				if (notYourTurn) throw new NotYourTurnException();
			}
			catch (BidUnderPermittedException e)
			{
				Console.WriteLine(e);
				throw;
			}
			catch (NotYourTurnException e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}

	public class Turn
	{
		internal Turn(Player player)
		{
			Player = player;
		}

		public Player Player { get; }
	}
}