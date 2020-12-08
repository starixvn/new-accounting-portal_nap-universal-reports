using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<SummaryModel>>();
            var service = Substitute.For<SummaryService>();
            service.GetSummaries(Arg.Compat.Any<Criteria>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(service);
            var viewModel = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}