using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Controllers;
using UniversalReports.CashOutPerformance.Requests;

namespace UniversalReports.CashOutPerformance.UnitTests.Controllers
{
    [TestFixture]
    [Category("CashOutPerformance")]
    public class CashOutPerformanceApiControllerTests
    {
        [Test]
        public async Task Sports_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.Sports();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<SportRequest>());
        }

        [Test]
        public async Task Licensees_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.Licensees();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<LicenseeRequest>());
        }

        [Test]
        public async Task Tickets_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.Tickets(new TicketRequest());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketRequest>());
        }

        [Test]
        public async Task TicketsExcel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.TicketsExcel(new TicketExcelRequest());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketExcelRequest>());
        }
    }
}
