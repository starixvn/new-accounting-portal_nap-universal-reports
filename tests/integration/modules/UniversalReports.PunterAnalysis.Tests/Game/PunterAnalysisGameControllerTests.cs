using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using UniversalReports.PunterAnalysis.Game;
using UniversalReports.PunterAnalysis.Game.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.Game
{
    public class PunterAnalysisGameControllerTests
    {
        private const string FakeRepositoryDataFileName = "Game-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Game-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("Game-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Game-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("Game-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<PunterAnalysisGameController, GameModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A8:E9"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A10:E10"].Value, expectedTotal);

            // Release
            container.Dispose();
        }
    }
}