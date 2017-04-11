using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.Tests.League
{
    public class PunterAnalysisLeagueControllerTests
    {
        private const string FakeRepositoryDataFileName = "League-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
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

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("League-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("League-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("League-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("League-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisLeagueController, LeagueRawModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { PeriodType = 1, Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.True(workSheet.Cells["A1:E2"].Merge);
            Assert.True(workSheet.Cells["A3:E5"].Merge);

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A7:E8"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A9:E9"].Value, expectedTotal);
            
            // Release
            factory.Dispose();
        }
    }
}