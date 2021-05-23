using System;
using Hasse.Core.GameAggregate.Player;
using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate.Team
{
    public interface ITeamBuilder : ILazyBuilder<Team>
    {
        TeamBuilder WithPlayer(Action<IPlayerBuilder> builder);
    }
}