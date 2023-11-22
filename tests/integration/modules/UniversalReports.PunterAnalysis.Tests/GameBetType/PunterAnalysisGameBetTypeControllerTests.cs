using System.Threading.Tasks;
using NUnit.Framework;
using SimpleInjector;
using UniversalReports.PunterAnalysis.GameBetType;
using UniversalReports.PunterAnalysis.GameBetType.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.GameBetType
{
    using Results;

    public class PunterAnalysisGameBetTypeControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetType-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("GameBetType-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<PunterAnalysisGameBetTypeController, GameBetTypeModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:M2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:M8"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A12:M13"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A14:M14"].Value, expectedTotal);

            // Release
            container.Dispose();
        }
    }
}