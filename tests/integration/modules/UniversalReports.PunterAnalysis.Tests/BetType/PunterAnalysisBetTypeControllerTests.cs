using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.Tests.BetType
{
    public class PunterAnalysisBetTypeControllerTests
    {
        private const string FakeRepositoryDataFileName = "BetType-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string ExpectedViewModelJsonFileName = "BetType-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisBetTypeController, BetTypeModel>(FakeRepositoryDataFileName);

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
            var expectedTitle = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetType-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisBetTypeController, BetTypeModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.True(workSheet.Cells["A1:M2"].Merge);
            Assert.True(workSheet.Cells["A3:M5"].Merge);

            Assert.AreEqual(workSheet.Cells["A1:M2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:M5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A9:M10"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A11:M11"].Value, expectedTotal);

            // Release
            factory.Dispose();
        }
    }
}