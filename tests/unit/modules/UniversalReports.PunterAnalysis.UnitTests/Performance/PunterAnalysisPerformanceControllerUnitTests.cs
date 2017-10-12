using System;
using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Performance;
using UniversalReports.PunterAnalysis.Performance.Sportsbook;
using UniversalReports.PunterAnalysis.Performance.Summary;

namespace UniversalReports.PunterAnalysis.UnitTests.Performance
{
    public class PunterAnalysisPerformanceControllerUnitTests
    {
        [Test]
        public async Task Summary_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new SummaryHttpParameterJson
            {
                FromDate = new DateTime(2016, 1, 15),
                ToDate = new DateTime(2016, 2, 17)
            };

            // Act
            var controller = new PunterAnalysisPerformanceController(mediator);
            await controller.Summary(httpParameterJson);

            // Assert
            await mediator.Received().Send(httpParameterJson);
        }

        [Test]
        public async Task Sportsbook_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new SportsbookHttpParameterJson
            {
                FromDate = new DateTime(2016, 1, 15),
                ToDate = new DateTime(2016, 2, 17)
            };

            // Act
            var controller = new PunterAnalysisPerformanceController(mediator);
            await controller.Sportsbook(httpParameterJson);

            // Assert
            await mediator.Received().Send(httpParameterJson);
        }
    }
}