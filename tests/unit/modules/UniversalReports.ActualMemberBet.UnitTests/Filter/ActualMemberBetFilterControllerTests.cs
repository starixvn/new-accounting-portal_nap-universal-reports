using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Filter;

namespace UniversalReports.ActualMemberBet.UnitTests.Filter
{
    [TestFixture]
    public class ActualMemberBetFilterControllerTests
    {
        [Test]
        public async Task Currency_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new ActualMemberBetFilterController(mediator);
            await controller.Currency();

            // Assert
            await mediator.Received().Send(Arg.Any<CurrencyHttpParameter>());
        }

        [Test]
        public async Task Site_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new ActualMemberBetFilterController(mediator);
            await controller.Site();

            // Assert
            await mediator.Received().Send(Arg.Any<SiteHttpParameter>());
        }

        [Test]
        public async Task Odds_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new ActualMemberBetFilterController(mediator);
            await controller.Odds();

            // Assert
            await mediator.Received().Send(Arg.Any<OddsHttpParameter>());
        }
    }
}
