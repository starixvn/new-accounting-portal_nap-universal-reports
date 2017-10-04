using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<ReportModel>();
            var factory = CreateLeagueServiceFactory(anyReportModel);

            // Act
            var handler = new Handler(factory);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }

        private LeagueServiceFactory CreateLeagueServiceFactory(ReportModel reportModel)
        {
            var service = Substitute.For<LeagueService>();
            service.Query(Arg.Any<ICriteria>()).Returns(reportModel);

            var factory = Substitute.For<LeagueServiceFactory>();
            factory.CreateLeagueService(Arg.Any<int>()).Returns(service);

            return factory;
        }
    }
}