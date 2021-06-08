using System;
using Hasse.SharedKernel;

namespace Shared.TwoTeamsCardGame.Team
{
    public interface ITeamBuilder<TPlayer, out TPlayerBuilder> : ILazyBuilder<Team>
    {
	    ITeamBuilder<TPlayer, TPlayerBuilder> WithPlayer(Action<TPlayerBuilder> builder);
    }
}