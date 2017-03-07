using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.BetType
{
    public class PunterAnalysisBetTypeControllerUnitTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new PunterAnalysisBetTypeController(mediator);
            var result = controller.Index(new HttpParameterJson());

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterJson>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new PunterAnalysisBetTypeController(mediator);
            var result = controller.Excel(new HttpParameterExcel());

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterExcel>());
        }
    }
}
