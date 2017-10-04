using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PlayForFun.Summary;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.UnitTests.Summary
{
    public class PlayForFunSummaryControllerUnitTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new HttpParameterJson();

            // Act
            var controller = new PlayForFunSummaryController(mediator);
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
            var controller = new PlayForFunSummaryController(mediator);
            await controller.Excel(httpParameterExcel);

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterExcel>());
        }
    }
}