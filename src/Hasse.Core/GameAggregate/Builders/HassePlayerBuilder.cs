using Hasse.SharedKernel;

namespace Hasse.Core.GameAggregate
{
    public class HassePlayerBuilder : LazyBuilder<DiagonalTeamPlayer,HassePlayerBuilder>
    {
        private string _name;

        public HassePlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public HassePlayerBuilder WithPosition(DiagonalTeamPlayer.TablePosition position)
        {
            Do(p => p.Position = position);
            return this;
        }

        protected override DiagonalTeamPlayer Construct()
        {
            return new(_name);
        }
    }
}