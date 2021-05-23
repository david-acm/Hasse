namespace Hasse.Core.GameAggregate.Team
{
    public class DefaultTeamFactory : TwoPlayersTeamFactory
    {
        protected override Team CreateTeam(Player.Player player1, Player.Player player2)
        {
            return new((player1, player2));
        }
    }
}