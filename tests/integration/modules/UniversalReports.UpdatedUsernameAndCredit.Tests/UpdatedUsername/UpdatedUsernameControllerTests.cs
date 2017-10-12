using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Results;
using SimpleInjector;
using UniversalReports.UpdatedUsernameCredit.Tests.DependencyInjection;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit.Tests.UpdatedUsername
{
    [TestFixture]
    public class UpdatedUsernameControllerTests
    {
        private const string FakeRepositoryDataFileName = "UpdatedUsername/UpdatedUsername-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("UpdatedUsername/UpdatedUsername-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("UpdatedUsername/UpdatedUsername-Excel-ExpectedBody.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<UpdatedUsernameController, UpdatedUsernameEntity>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(
                new ExcelMessage
                {
                    FromDate = new DateTime(2017, 10, 1),
                    ToDate = new DateTime(2017, 10, 20),
                    Username = string.Empty
                });

            var excelPackage = (httpActionResult as ExcelResult).ExcelPackage;
            var workSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(workSheet.Name, Is.EqualTo("Updated Username"));

            Assert.AreEqual(workSheet.Cells["A1:N2"].Value, expectedTitle);
            Assert.AreEqual(workSheet.Cells["A5:N6"].Value, expectedBody);

            // Release
            container.Dispose();
        }
    }
}
