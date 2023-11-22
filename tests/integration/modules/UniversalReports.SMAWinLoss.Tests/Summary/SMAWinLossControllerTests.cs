using NUnit.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Summary;
using UniversalReports.SMAWinLoss.Tests.DependencyInjection;

namespace UniversalReports.SMAWinLoss.Tests.Summary
{
    using Results;

    [TestFixture]
    public class SMAWinLossControllerTests
    {
        private const string FakeRepositoryBodyDataFileName = "SMAWinLoss-FileBodyRepository.json";
        private const string FakeRepositoryTotalDataFileName = "SMAWinLoss-FileTotalRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("Summary-Excel-ExpectedTotal.json");

            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<SMAWinLossController, WinLossEntity>(FakeRepositoryBodyDataFileName, FakeRepositoryTotalDataFileName, 1);

            // Act
            var httpActionResult = await controller.Excel(new WinLossHttpParameterExcel
            {
                Year = 2020,
                Title = "Title"
            });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var summaryWorkSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(summaryWorkSheet.Name, Is.EqualTo("SMA Win Loss Summary"));

            Assert.That(summaryWorkSheet.Cells["A1:Q1"].Value, Is.EqualTo(expectedTitle));
            Assert.That(summaryWorkSheet.Cells["A4:Q8"].Value, Is.EqualTo(expectedBody));
            Assert.That(summaryWorkSheet.Cells["A9:Q11"].Value, Is.EqualTo(expectedTotal));

            // Release
            container.Dispose();
        }
    }
}