using System;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
    public interface ITeamBuilder : ILazyBuilder<Team>
    {
	    ITeamBuilder WithPlayer(Action<IPlayerBuilder> builder);
    }
}