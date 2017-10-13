using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using UniversalReports.UpdatedUsernameCredit.Tests.DependencyInjection;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;

namespace UniversalReports.UpdatedUsernameCredit.Tests.UpdatedCredit
{
    [TestFixture]
    public class UpdatedCreditControllerTests
    {
        private const string FakeRepositoryDataFileName = "UpdatedCredit/UpdatedCredit-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("UpdatedCredit/UpdatedCredit-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("UpdatedCredit/UpdatedCredit-Excel-ExpectedBody.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<UpdatedCreditController, UpdatedCreditEntity>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(
                new ExcelMessage
                {
                    FromDate = new DateTime(2017, 10, 1),
                    ToDate = new DateTime(2017, 10, 20),
                    Username = string.Empty
                });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Updated Credit"));

            Assert.AreEqual(workSheet.Cells["A1:O2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A5:O7"].Value, expectedBody);

            // Release
            container.Dispose();
        }
    }
}
