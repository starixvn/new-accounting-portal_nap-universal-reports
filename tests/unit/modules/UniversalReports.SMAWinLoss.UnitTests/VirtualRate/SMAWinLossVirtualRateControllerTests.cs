using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.VirtualRate;

namespace UniversalReports.SMAWinLoss.UnitTests.VirtualRate
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class SMAWinLossVirtualRateControllerTests
    {
        [Test]
        public async Task VirtualRate_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossVirtualRateController(mediator);
            await controller.VirtualRate(new VirtualRateHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<VirtualRateHttpParameter>());
        }
    }
}