using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.HouseWinLoss.Tests;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.Summary
{
    public class PunterAnalysisSummaryControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Summary-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "Summary-ExpectedViewModelJson.json";

            var fakeSummaryModelListFromRepository = TestDataLoader.Load<List<SummaryModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SummaryModel>(Arg.Any<ICriteria>()).Returns(fakeSummaryModelListFromRepository);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisSummaryController)) as PunterAnalysisSummaryController;
            var httpActionResult = await controller.Index(new HttpParameterJson());
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }
    }
}
