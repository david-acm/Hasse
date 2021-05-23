using System;
using System.Threading;
using System.Threading.Tasks;
using Hasse.Core.Interfaces;
using Hasse.Core.ProjectAggregate;
using Hasse.Core.ProjectAggregate.Events;
using Hasse.Core.ProjectAggregate.Handlers;
using Moq;
using Xunit;

namespace Hasse.UnitTests.Core.Handlers
{
    public class ItemCompletedEmailNotificationHandlerHandle
    {
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly ItemCompletedEmailNotificationHandler _handler;

        public ItemCompletedEmailNotificationHandlerHandle()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _handler = new ItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            Exception ex =
                await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task SendsEmailGivenEventInstance()
        {
            await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()), CancellationToken.None);

            _emailSenderMock.Verify(
                sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()), Times.Once);
        }
    }
}