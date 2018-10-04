using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<BetCountModel>>();
            var service = Substitute.For<BetCountService>();
            service.Query(Arg.Any<Criteria>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(service);
            var viewModel = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}