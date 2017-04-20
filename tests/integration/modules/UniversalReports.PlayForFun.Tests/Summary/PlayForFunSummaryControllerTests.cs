using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PlayForFun.Summary;
using UniversalReports.PlayForFun.Summary.Model;
using UniversalReports.PlayForFun.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PlayForFun.Tests.Summary
{
    public class PlayForFunSummaryControllerTests
    {
        private const string FakeRepositoryDataFileName = "Summary-FileRepository.json";
        private const string FakeDetailRepositoryDataFileName = "Detail-FileRepository.json";

        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string ExpectedViewModelJsonFileName = "Summary-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunSummaryController, SummaryModel>(FakeRepositoryDataFileName);

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
            var expectedSummaryTitle = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTitle.json");
            var expectedSummaryBody = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedBody.json");
            var expectedSummaryTotal = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTotal.json");

            var expectedDetailTitle = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedTitle.json");
            var expectedDetailBody = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedBody.json");
            var expectedDetailTotal = TestDataLoader.Load<object[,]>("Detail-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunSummaryController, SummaryModel, PlayForFun.Detail.Model.DetailModel>(
                FakeRepositoryDataFileName,
                FakeDetailRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", ProductName = "RNG Casino" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var summaryWorkSheet = excelPackage.Workbook.Worksheets[1];
            var detailWorkSheet = excelPackage.Workbook.Worksheets[2];

            // Assert
            Assert.That(summaryWorkSheet.Name, Is.EqualTo("Summary"));
            Assert.That(detailWorkSheet.Name, Is.EqualTo("RNG Casino Statistics"));

            Assert.That(summaryWorkSheet.Cells["A1:E1"].Value, Is.EqualTo(expectedSummaryTitle));
            Assert.That(summaryWorkSheet.Cells["A4:E5"].Value, Is.EqualTo(expectedSummaryBody));
            Assert.That(summaryWorkSheet.Cells["A6:E6"].Value, Is.EqualTo(expectedSummaryTotal));

            Assert.That(detailWorkSheet.Cells["A1:M1"].Value, Is.EqualTo(expectedDetailTitle));
            Assert.That(detailWorkSheet.Cells["A4:M5"].Value, Is.EqualTo(expectedDetailBody));
            Assert.That(detailWorkSheet.Cells["A6:M6"].Value, Is.EqualTo(expectedDetailTotal));

            // Release
            factory.Dispose();
        }
    }
}