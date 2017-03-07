using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class PunterAnalysisSummaryControllerUnitTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new PunterAnalysisSummaryController(mediator);

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterJson>());
        }      
    }
}
