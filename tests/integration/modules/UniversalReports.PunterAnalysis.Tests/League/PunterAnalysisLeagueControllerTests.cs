using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
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
            ViewModelJson viewModelJson = null;
            const string FakeRepositoryDataFileName = "League-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "League-ExpectedViewModelJson.json";

            var fakeLeagueModelListFromRepository = TestDataLoader.Load<List<LeagueRawModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(fakeLeagueModelListFromRepository);

            // Act
            PunterAnalysisLeagueController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisLeagueController)) as PunterAnalysisLeagueController;
                var httpParameterJson = new HttpParameterJson { PeriodType = 1 };
                var httpActionResult = await controller.Index(httpParameterJson);
                viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;
            }

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }
    }
}