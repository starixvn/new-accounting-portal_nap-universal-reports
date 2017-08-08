using NUnit.Framework;
using SimpleInjector;
using System;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using Olympus.WebApi.Results;

namespace UniversalReports.PunterAnalysis.Tests.BetType
{
    public class PunterAnalysisBetTypeControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetType-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<PunterAnalysisBetTypeController, BetTypeModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.AreEqual(workSheet.Cells["A1:M2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:M5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A9:M10"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A11:M11"].Value, expectedTotal);

            // Release
            container.Dispose();
        }
    }
}