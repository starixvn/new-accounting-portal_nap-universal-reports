using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Controllers;
using UniversalReports.CashOutPerformance.Models;
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
        public async Task Leagues_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            var leagueRequest = new LeagueRequest();
            await controller.Leagues(leagueRequest);

            // Assert
            await mediator.Received().Send(leagueRequest);
        }

        [Test]
        public async Task LeagueGroups_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.LeagueGroups();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<LeagueGroupRequest>());
        }

        [Test]
        public async Task SportLevel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            var request = new SportLevelRequest();
            await controller.SportLevel(request);

            // Assert
            await mediator.Received().Send(request);
        }

        [Test]
        public async Task EventStatusLevel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            var request = new TicketRequest<EventStatusLevelModel>();
            await controller.EventStatusLevel(request);

            // Assert
            await mediator.Received().Send(request);
        }

        [Test]
        public async Task BetTypeLevel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            var request = new TicketRequest<BetTypeLevelModel>();
            await controller.BetTypeLevel(request);

            // Assert
            await mediator.Received().Send(request);
        }

        [Test]
        public async Task MatchDetailLevel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            var request = new TicketRequest<MatchDetailLevelModel>();
            await controller.MatchDetailLevel(request);

            // Assert
            await mediator.Received().Send(request);
        }

        [Test]
        public async Task TicketsExcelOfSport_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.TicketsExcel(new SportLevelExcelRequest());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketExcelRequest<SportLevelModel>>());
        }

        [Test]
        public async Task TicketsExcelOEventt_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.TicketsExcel(new TicketExcelRequest<EventStatusLevelModel>());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketExcelRequest<EventStatusLevelModel>>());
        }

        [Test]
        public async Task TicketsExcelOfBetType_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.TicketsExcel(new TicketExcelRequest<BetTypeLevelModel>());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketExcelRequest<BetTypeLevelModel>>());
        }

        [Test]
        public async Task TicketsExcelOfMatch_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new CashOutPerformanceApiController(mediator);
            await controller.TicketsExcel(new TicketExcelRequest<MatchDetailLevelModel>());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<TicketExcelRequest<MatchDetailLevelModel>>());
        }
    }
}