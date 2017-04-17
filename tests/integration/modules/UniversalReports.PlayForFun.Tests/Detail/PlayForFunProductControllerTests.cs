using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PlayForFun.Detail;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

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

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunDetailController, DetailModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A8:E9"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A10:E10"].Value, expectedTotal);

            // Release
            factory.Dispose();
        }
    }
}