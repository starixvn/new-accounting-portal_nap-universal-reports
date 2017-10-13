using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.BetCount
{
    public class PunterAnalysisBetCountControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetCount-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<PunterAnalysisBetCountController, BetCountRawModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E4"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A7:E8"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A9:E9"].Value, expectedTotal);

            // Release
            container.Dispose();
        }
    }
}