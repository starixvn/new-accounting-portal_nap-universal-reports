using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using UniversalReports.Exchange.Report;
using UniversalReports.Exchange.Tests.DependencyInjection;

namespace UniversalReports.Exchange.Tests.Report
{
    [TestFixture]
    public class ExchangeControllerTest
    {
        private const string FakeRepositoryDataFileName = "Exchange-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedExchangeTitle = TestDataLoader.Load<object[,]>("Exchange-Excel-ExpectedTitle.json");
            var expectedExchangeBody = TestDataLoader.Load<object[,]>("Exchange-Excel-ExpectedBody.json");
            var expectedExchangeTotal = TestDataLoader.Load<object[,]>("Exchange-Excel-ExpectedTotal.json");


            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<ExchangeController, ExchangeEntity>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel
            {
                FromDate = new DateTime(2018, 9, 1),
                ToDate = new DateTime(2018, 9, 20),
                LicenseeName = "12Bet",
                EventType = "SOCCER,TENNIS,CRICKET,HORSE_RACING,FANCYBET,BASKETBALL,FANCYBET",
                DrillLevel = 1
            });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var summaryWorkSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(summaryWorkSheet.Name, Is.EqualTo("Exchange"));

            Assert.That(summaryWorkSheet.Cells["A1:N1"].Value, Is.EqualTo(expectedExchangeTitle));
            Assert.That(summaryWorkSheet.Cells["A5:N6"].Value, Is.EqualTo(expectedExchangeBody));
            Assert.That(summaryWorkSheet.Cells["A7:N7"].Value, Is.EqualTo(expectedExchangeTotal));

            // Release
            container.Dispose();
        }
    }
}
