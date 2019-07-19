using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using filter = UniversalReports.Exchange.Filter;

namespace UniversalReports.Exchange.UnitTests.Filter
{
    [TestFixture]
    public class ExchangeFilterControllerTests
    {
        [Test]
        public async Task Licensee_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new filter.ExchangeFilterController(mediator);
            await controller.Licensee();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<filter.Licensee.HttpParameterJson>());
        }

        [Test]
        public async Task Sport_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new filter.ExchangeFilterController(mediator);
            await controller.Sport();

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<filter.Sport.HttpParameterJson>());
        }
    }
}
