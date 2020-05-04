using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Filter;
using UniversalReports.AbnormalBet.HttpParameter;

namespace UniversalReports.AbnormalBet.UnitTests.Filter
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class AbnormalBetFilterControllerTests
    {
        [Test]
        public async Task Reason_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetFilterController(mediator);
            await controller.Reason();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<ReasonHttpParameter>());
        }

        [Test]
        public async Task Site_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetFilterController(mediator);
            await controller.Site();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<SiteHttpParameter>());
        }

        [Test]
        public async Task BetType_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetFilterController(mediator);
            await controller.BetType(new BetTypeHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<BetTypeHttpParameter>());
        }

        public async Task Sport_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetFilterController(mediator);
            await controller.Sport();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<SportHttpParameter>());
        }
    }
}
