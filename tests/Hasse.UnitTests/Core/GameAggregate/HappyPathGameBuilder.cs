using Hasse.Core.GameAggregate;
using Hasse.Core.GameAggregate.Player;
using Hasse.Core.GameAggregate.Team;
using Hasse.SharedKernel;

namespace Hasse.UnitTests.Core.GameAggregate
{
    public sealed class HappyPathGameBuilder : LazyBuilder<HasseGame, HappyPathGameBuilder>
    {
        private const string Player1Name = "David";
        private const string Player2Name = "Allison";
        private const string Player3Name = "Greta";
        private const string Player4Name = "Joe";

        protected override HasseGame Construct()
        {
            var builder = new GameBuilder(new TeamBuilderFactory(new PlayerBuilder()));

            builder
                .WithTeam("Colombia",
                    team => team
                        .WithPlayer(p => p.WithName(Player1Name))
                        .WithPlayer(p => p.WithName(Player2Name)))
                .WithTeam("America",
                    team => team
                        .WithPlayer(p => p.WithName(Player3Name))
                        .WithPlayer(p => p.WithName(Player4Name)));

            return builder.Build();
        }
    }
}