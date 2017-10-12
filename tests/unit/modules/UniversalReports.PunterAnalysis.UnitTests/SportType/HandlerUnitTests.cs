using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.SportType
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<SportTypeModel>>();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<SportTypeModel>(Arg.Any<ICriteria>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}