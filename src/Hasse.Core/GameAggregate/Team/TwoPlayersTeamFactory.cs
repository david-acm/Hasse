using Ardalis.GuardClauses;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
    public abstract class TwoPlayersTeamFactory
    {
        protected abstract Team CreateTeam(Player player1, Player player2);

        public Team GetTeam(Player player1, Player player2)
        {
            Guard.Against.Null(player1, nameof(player1));
            Guard.Against.Null(player2, nameof(player2));

            return CreateTeam(player1, player2);
        }
    }
}