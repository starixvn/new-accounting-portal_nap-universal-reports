using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Summary;

namespace UniversalReports.SMAWinLoss.UnitTests.Summary
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class SMAWinLossControllerTests
    {
        [Test]
        public async Task Summary_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossController(mediator);
            await controller.Summary(new WinLossHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<WinLossHttpParameter>());
        }
    }
}