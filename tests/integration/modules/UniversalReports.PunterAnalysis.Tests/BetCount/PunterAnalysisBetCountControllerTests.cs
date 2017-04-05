using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using OfficeOpenXml;
using System.Collections.Generic;
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
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            ViewModelJson viewModelJson = null;
            const string FakeRepositoryDataFileName = "BetCount-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "BetCount-ExpectedViewModelJson.json";

            var fakeBetCountModelListFromRepository = TestDataLoader.Load<List<BetCountModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Any<ICriteria>()).Returns(fakeBetCountModelListFromRepository);

            PunterAnalysisBetCountController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisBetCountController)) as PunterAnalysisBetCountController;
                var httpActionResult = await controller.Index(new HttpParameterJson());
                viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;
            }

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            ExcelPackage excelPackage = null;
            ExcelWorksheet workSheet = null;
            const string FakeRepositoryDataFileName = "BetCount-FileRepository.json";

            var fakeSportTypeModelListFromRepository = TestDataLoader.Load<List<BetCountModel>>(FakeRepositoryDataFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Any<ICriteria>()).Returns(fakeSportTypeModelListFromRepository);

            var expectedTitle = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("BetCount-Excel-ExpectedTotal.json");

            // Act
            PunterAnalysisBetCountController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisBetCountController)) as PunterAnalysisBetCountController;
                var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
                excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
                workSheet = excelPackage.Workbook.Worksheets[1];
            }

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.True(workSheet.Cells["A1:E2"].Merge);
            Assert.True(workSheet.Cells["A3:E4"].Merge);

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E4"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A7:E8"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A9:E9"].Value, expectedTotal);
        }
    }
}