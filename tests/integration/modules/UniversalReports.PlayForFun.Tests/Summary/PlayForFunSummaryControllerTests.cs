using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PlayForFun.Summary;
using UniversalReports.PlayForFun.Summary.Model;
using UniversalReports.PlayForFun.Tests.DependencyInjection;

namespace UniversalReports.PlayForFun.Tests.Summary
{
    public class PlayForFunSummaryControllerTests
    {
        private const string FakeRepositoryDataFileName = "Summary-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string ExpectedViewModelJsonFileName = "Summary-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunSummaryController, SummaryModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Index(new HttpParameterJson());
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));

            // Release
            factory.Dispose();
        }
    }
}