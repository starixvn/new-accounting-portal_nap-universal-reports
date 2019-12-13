using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.GameBetType;
using UniversalReports.PunterAnalysis.GameBetType.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.GameBetType
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<Linq.DynamicSum.SummaryEntity<GameBetTypeModel>>();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<GameBetTypeModel>(Arg.Compat.Any<ICriteria>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(service);
            var viewModel = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}