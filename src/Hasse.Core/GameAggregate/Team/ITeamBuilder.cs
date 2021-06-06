using System;
using Hasse.SharedKernel;
using Shared.CardGame.Player;

namespace Hasse.Core.GameAggregate.Team
{
    public interface ITeamBuilder<TPlayer, out TPlayerBuilder> : ILazyBuilder<Team>
    {
	    ITeamBuilder<TPlayer, TPlayerBuilder> WithPlayer(Action<TPlayerBuilder> builder);
    }
}