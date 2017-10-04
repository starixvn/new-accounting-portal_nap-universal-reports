using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameAndCredit.UnitTests.UpdatedUsername
{
    [TestFixture]
    public class UpdatedUsernameControllerTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var message = new Message();

            // Act
            var controller = new UpdatedUsernameController(mediator);
            await controller.Query(message);

            // Assert
            await mediator.Received().Send(Arg.Any<Message>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var excelMessage = new ExcelMessage();

            // Act
            var controller = new UpdatedUsernameController(mediator);
            await controller.Excel(excelMessage);

            // Assert
            await mediator.Received().Send(Arg.Any<ExcelMessage>());
        }
    }
}