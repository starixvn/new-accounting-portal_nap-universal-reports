using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedCredit
{
    [TestFixture]
    public class UpdatedCreditControllerTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var message = new Message();

            // Act
            var controller = new UpdatedCreditController(mediator);
            await controller.Query(message);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<Message>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var excelMessage = new ExcelMessage();

            // Act
            var controller = new UpdatedCreditController(mediator);
            await controller.Excel(excelMessage);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<ExcelMessage>());
        }
    }
}