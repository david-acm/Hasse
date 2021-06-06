using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
    public class DefaultTeamFactory : TwoPlayersTeamFactory
    {
        protected override Team CreateTeam(Player player1, Player player2)
        {
            return new((player1, player2));
        }
    }
}