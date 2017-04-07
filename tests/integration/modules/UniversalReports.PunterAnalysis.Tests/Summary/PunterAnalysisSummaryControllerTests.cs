using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.Tests.Summary
{
    public class PunterAnalysisSummaryControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Summary-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "Summary-ExpectedViewModelJson.json";

            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisSummaryController, SummaryModel>(FakeRepositoryDataFileName);

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
            const string FakeRepositoryDataFileName = "Summary-FileRepository.json";

            var fakeSummaryModelListFromRepository = TestDataLoader.Load<List<SummaryModel>>(FakeRepositoryDataFileName);

            var expectedTitle = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTotal.json");

            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisSummaryController, SummaryModel>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.True(workSheet.Cells["A1:E2"].Merge);
            Assert.True(workSheet.Cells["A3:E5"].Merge);

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A8:E9"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A10:E10"].Value, expectedTotal);

            // Release
            factory.Dispose();
        }
    }
}