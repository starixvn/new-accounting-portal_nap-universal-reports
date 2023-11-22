using System.Threading.Tasks;
using NUnit.Framework;
using SimpleInjector;
using UniversalReports.PunterAnalysis.BetTypeGroup;
using UniversalReports.PunterAnalysis.BetTypeGroup.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.BetTypeGroup
{
    using Results;

    public class PunterAnalysisBetTypeGroupControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetTypeGroup-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("BetTypeGroup-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetTypeGroup-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetTypeGroup-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetTypeGroup-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<PunterAnalysisBetTypeGroupController, BetTypeGroupModel>(FakeRepositoryDataFileName);

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