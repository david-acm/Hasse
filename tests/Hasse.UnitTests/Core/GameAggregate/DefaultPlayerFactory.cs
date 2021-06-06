using System;
using Shared.CardGame.Player;
using Xunit;

namespace Hasse.UnitTests.Core.GameAggregate
{
    public class DefaultPlayerFactoryShould
    {
        [Fact]
        public void ThrowArgumentException_WhenEmptyNameIsPassed()
        {
            // Prepare
            var factory = new DefaultPlayerFactory();

            // Execute
            var exception = Assert.Throws<ArgumentException>(() => factory.GetPlayer(string.Empty));

            // Assert
            Assert.Equal("name", exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentNullException_WhenNullNameIsPassed()
        {
            // Prepare
            var factory = new DefaultPlayerFactory();

            // Execute
            var exception = Assert.Throws<ArgumentNullException>(() => factory.GetPlayer(null));

            // Assert
            Assert.Equal("name", exception.ParamName);
        }
    }
}