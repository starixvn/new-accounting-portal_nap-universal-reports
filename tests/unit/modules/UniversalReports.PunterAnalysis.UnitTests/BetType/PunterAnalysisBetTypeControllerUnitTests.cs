using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
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
            var httpParameterJson = new HttpParameterJson();

            // Act
            var controller = new PunterAnalysisBetTypeController(mediator);
            await controller.Index(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterJson>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterExcel = new HttpParameterExcel();

            // Act
            var controller = new PunterAnalysisBetTypeController(mediator);
            await controller.Excel(httpParameterExcel);

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterExcel>());
        }
    }
}