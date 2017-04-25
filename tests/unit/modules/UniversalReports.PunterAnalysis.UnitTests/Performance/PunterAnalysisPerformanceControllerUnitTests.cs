using MediatR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance;
using UniversalReports.PunterAnalysis.Performance.Summary;

namespace UniversalReports.PunterAnalysis.UnitTests.Performance
{
    public class PunterAnalysisPerformanceControllerUnitTests
    {
        [Test]
        public async Task Summary_Always_CallMediatorSendByDateTimeWithFirstDayOfMonth()
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
            await mediator.Received().Send(Arg.Is<SummaryHttpParameterJson>(x => x.FromDate.Day == 1 && x.ToDate.Day == 1));
        }
    }
}