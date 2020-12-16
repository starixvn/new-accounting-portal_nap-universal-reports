using AutoFixture;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Olympus.FPSAPI.Client;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class SummaryServiceUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task GetSummaries_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<SummaryModel>>();
            var category = fixture.Create<string>();
            var service = Substitute.For<PunterAnalysisService>();
            var configurationService = Substitute.For<ConfigurationService>();
            var fraudServiceWrapper = Substitute.For<FraudServiceWrapper>();

            service.Query<SummaryModel>(Arg.Compat.Any<ICriteria>()).Returns(anyReportModel);
            fraudServiceWrapper.GetCategory(Arg.Compat.Any<string>(), Arg.Compat.Any<string>()).Returns(category);

            // Act
            var summaryService = new SummaryServiceImp(service, fraudServiceWrapper, configurationService);
            var viewModel = await summaryService.GetSummaries(new Criteria());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}