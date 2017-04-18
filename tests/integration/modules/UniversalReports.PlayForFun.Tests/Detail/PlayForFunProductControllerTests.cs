using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PlayForFun.Detail;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Tests.DependencyInjection;

namespace UniversalReports.PlayForFun.Tests.Detail
{
    public class PlayForFunDetailControllerTests
    {
        private const string FakeRepositoryDataFileName = "Detail-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string ExpectedViewModelJsonFileName = "Detail-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunDetailController, DetailModel>(FakeRepositoryDataFileName);

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