using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Filter;

namespace UniversalReports.SMAWinLoss.UnitTests.Filter
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class SMAWinLossFilterControllerTests
    {
        [Test]
        public async Task Sport_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossFilterController(mediator);
            await controller.Sport();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<SportHttpParameter>());
        }

        [Test]
        public async Task Site_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossFilterController(mediator);
            await controller.Site();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<SiteHttpParameter>());
        }

        [Test]
        public async Task Currency_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossFilterController(mediator);
            await controller.Currency();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<CurrencyHttpParameter>());
        }

        public async Task LeagueGroup_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new SMAWinLossFilterController(mediator);
            await controller.LeagueGroup(new LeagueGroupHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<LeagueGroupHttpParameter>());
        }
    }
}