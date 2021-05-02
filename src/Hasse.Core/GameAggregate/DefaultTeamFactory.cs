namespace Hasse.Core.GameAggregate
{
    public class DefaultTeamFactory : TwoPlayersTeamFactory
    {
        protected override Team CreateTeam(Player player1, Player player2) => new(player1, player2);
    }
}