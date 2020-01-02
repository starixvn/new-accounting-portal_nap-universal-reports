using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Game;
using UniversalReports.PunterAnalysis.Game.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Game
{
    public class PunterAnalysisGameControllerUnitTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new HttpParameterJson();

            // Act
            var controller = new PunterAnalysisGameController(mediator);
            await controller.Index(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<HttpParameterJson>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterExcel = new HttpParameterExcel();

            // Act
            var controller = new PunterAnalysisGameController(mediator);
            await controller.Excel(httpParameterExcel);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<HttpParameterExcel>());
        }
    }
}