using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.Tests.BetCount
{
    public class PunterAnalysisBetCountControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetCount-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string ExpectedViewModelJsonFileName = "BetCount-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisBetCountController, BetCountRawModel>(FakeRepositoryDataFileName);

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
            var expectedTitle = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisBetCountController, BetCountRawModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E4"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A7:E8"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A9:E9"].Value, expectedTotal);

            // Release
            factory.Dispose();
        }
    }
}