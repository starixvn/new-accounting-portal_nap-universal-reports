using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.League
{
    public class PunterAnalysisLeagueControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "League-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "League-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            // Act
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisLeagueController, LeagueRawModel>(FakeRepositoryDataFileName);
            var httpParameterJson = new HttpParameterJson { PeriodType = 1 };
            var httpActionResult = await controller.Index(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));

            // Release
            factory.Dispose();
        }
    }
}