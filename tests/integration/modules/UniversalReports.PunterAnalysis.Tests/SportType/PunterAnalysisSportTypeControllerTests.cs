using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.Tests.SportType
{
    public class PunterAnalysisSportTypeControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            ViewModelJson viewModelJson = null;
            const string FakeRepositoryDataFileName = "SportType-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "SportType-ExpectedViewModelJson.json";

            var fakeSportTypeModelListFromRepository = TestDataLoader.Load<List<SportTypeModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportTypeModel>(Arg.Any<ICriteria>()).Returns(fakeSportTypeModelListFromRepository);

            // Act
            PunterAnalysisSportTypeController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisSportTypeController)) as PunterAnalysisSportTypeController;
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
            const string FakeRepositoryDataFileName = "SportType-FileRepository.json";

            var fakeSportTypeModelListFromRepository = TestDataLoader.Load<List<SportTypeModel>>(FakeRepositoryDataFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportTypeModel>(Arg.Any<ICriteria>()).Returns(fakeSportTypeModelListFromRepository);

            var expectedTitle = TestDataLoader.Load<object[,]>("SportType-Excel-ExpectedTitle.json");
            var expectedFilter = TestDataLoader.Load<object[,]>("SportType-Excel-ExpectedFilter.json");
            var expectedBody = TestDataLoader.Load<object[,]>("SportType-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("SportType-Excel-ExpectedTotal.json");

            // Act
            PunterAnalysisSportTypeController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisSportTypeController)) as PunterAnalysisSportTypeController;
                var httpActionResult = await controller.Excel(new HttpParameterExcel { Title = "Any Title", Filter = "Any Filter" });
                excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
                workSheet = excelPackage.Workbook.Worksheets[1];
            }

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Punter Analysis"));

            Assert.True(workSheet.Cells["A1:E2"].Merge);
            Assert.True(workSheet.Cells["A3:E5"].Merge);

            Assert.AreEqual(workSheet.Cells["A1:E2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A3:E5"].Value, expectedFilter);
            Assert.AreEqual(workSheet.Cells["A8:E9"].Value, expectedBody);
            Assert.AreEqual(workSheet.Cells["A10:E10"].Value, expectedTotal);
        }
    }
}