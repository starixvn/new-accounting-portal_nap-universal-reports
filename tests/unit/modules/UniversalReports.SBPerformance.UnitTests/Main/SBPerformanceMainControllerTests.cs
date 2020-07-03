using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.SBPerformance.UnitTests.Main
{
    [TestFixture]
    [Category("SBPerformance")]
    public class SBPerformanceMainControllerTests
    {
        [Test]
        public async Task Main_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameter = new HttpParameter();

            // Act
            var controller = new SBPerformanceMainController(mediator);
            await controller.Main(httpParameter);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<HttpParameter>());
        }
    }
}